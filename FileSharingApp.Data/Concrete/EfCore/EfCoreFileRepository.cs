using FileSharingApp.Data.Abstract;
using FileSharingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<File> GetFilesByUserId(string userId)
        {
            return FileDbContext.Files.Where(f => f.UserId == userId).ToList();
        }
    }
}
