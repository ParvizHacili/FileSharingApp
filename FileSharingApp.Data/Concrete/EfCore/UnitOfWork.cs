using FileSharingApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingApp.Data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FileDbContext _fileDbContext;
        public UnitOfWork(FileDbContext fileDbContext)
        {
            _fileDbContext = fileDbContext;
        }
        private EfCoreFileRepository _fileRepository;
        public IFileRepository Files => _fileRepository = _fileRepository ?? new EfCoreFileRepository(_fileDbContext);

        public void Dispose()
        {
            _fileDbContext.Dispose();
        }

        public void Save()
        {
            _fileDbContext.SaveChanges();
        }
    }
}
