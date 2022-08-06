using FileSharingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingApp.Data.Abstract
{
    public interface IFileRepository : IRepository<File>
    {
        List<File> GetFilesByUserId(string userId);
        File GetByIdWithUsers(int id);
        void Update(File entity, string[] userIds);
        List<File> SharedFiles(string userId);
    }
}
