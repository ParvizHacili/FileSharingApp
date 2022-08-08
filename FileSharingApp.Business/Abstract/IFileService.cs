using FileSharingApp.Data.Entities;
using System.Collections.Generic;


namespace FileSharingApp.Business.Abstract
{
    public interface IFileService
    {
        File GetById(int id);
        File GetByIdWithUsers(int id);
        List<File> GetAll();
        List<File> GetFilesByUserId(string userId);
        List<File> SharedFiles(string userId);
        void Create(File entity);
        void Update(File entity);
        void Update(File entity,string[] userIds);
        void UpdateIsDeleted(string userId);
        void Delete(File entity);
    }
}
