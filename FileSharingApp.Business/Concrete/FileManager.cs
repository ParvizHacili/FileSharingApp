using FileSharingApp.Business.Abstract;
using FileSharingApp.Data.Abstract;
using FileSharingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingApp.Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(File entity)
        {
            _unitOfWork.Files.Create(entity);
            _unitOfWork.Save();
        }

        public void Delete(File entity)
        {
            _unitOfWork.Files.Delete(entity);
            _unitOfWork.Save();
        }

        public List<File> GetAll()
        {
            return _unitOfWork.Files.GetAll();
        }

        public File GetById(int id)
        {
            return _unitOfWork.Files.GetById(id);
        }

        public File GetByIdWithUsers(int id)
        {
            return _unitOfWork.Files.GetByIdWithUsers(id);
        }

        public List<File> GetFilesByUserId(string userId)
        {
            return _unitOfWork.Files.GetFilesByUserId(userId);
        }

        public List<File> SharedFiles(string userId)
        {
            return _unitOfWork.Files.SharedFiles(userId);
        }

        public void Update(File entity)
        {
            _unitOfWork.Files.Update(entity);
            _unitOfWork.Save();
        }

        public void Update(File entity, string[] userIds)
        {
            _unitOfWork.Files.Update(entity, userIds);
            _unitOfWork.Save();
        }

        public void UpdateIsDeleted(string userId)
        {
            _unitOfWork.Files.UpdateIsDeleted(userId);
            _unitOfWork.Save();
        }
    }
}
