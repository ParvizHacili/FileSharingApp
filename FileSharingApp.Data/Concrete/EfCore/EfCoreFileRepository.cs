using FileSharingApp.Data.Abstract;
using FileSharingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace FileSharingApp.Data.Concrete.EfCore
{
    public class EfCoreFileRepository : EfCoreGenericRepository<File>, IFileRepository
    {
        public EfCoreFileRepository(FileDbContext context) : base(context)
        {

        }

        private FileDbContext FileDbContext
        {
            get { return context as FileDbContext; }
        }

        public File GetByIdWithUsers(int id)
        {
           return FileDbContext.Files.Where(f=>f.Id == id)
                .Include(f=>f.UserFiles)
                .ThenInclude(f=>f.User)
                .FirstOrDefault();
        }

        public List<File> GetFilesByUserId(string userId)
        {
            return FileDbContext.Files.Where(f => f.UserId == userId).ToList();
        }

        public List<File> SharedFiles(string userId)
        {
            var files = FileDbContext.Files.AsQueryable();
            if (!string.IsNullOrEmpty(userId))
            {
                files = files.Include(i => i.UserFiles)
                    .ThenInclude(i => i.User)
                    .Where(i => i.UserFiles.Any(a => a.User.Id == userId))
                    .Where(i => i.UserFiles.Any(a => a.IsDeleted == false));
            }
            return files.ToList();

        }

        public void Update(File entity, string[] userIds)
        {
           var file = FileDbContext.Files.Include(i=>i.UserFiles).FirstOrDefault(i=>i.Id == entity.Id);

            if (file!= null)
            {
                file.Name = entity.Name;
                file.Path = entity.Path;

                file.UserFiles = userIds.Select(Usid => new UserFile()
                {
                    FileId = entity.Id,
                    UserId = Usid
                }).ToList();
            }
        }

        public void UpdateIsDeleted(string userId)
        {
            var query = $"UPDATE UserFiles set IsDeleted='1' where ([UserId]='@userId')";

            FileDbContext.Database.ExecuteSqlRaw(query, userId);
        }
    }
}
