using FileSharingApp.Data.Entities;
using System.Collections.Generic;


namespace FileSharingApp.Business.Abstract
{
    public interface IFileService
    {
        File GetById(int id);
        List<File> GetAll();
        List<File> GetFilesByUserId(string userId);
        void Create(File entity);
        void Update(File entity);
        void Delete(File entity);
    }
}
