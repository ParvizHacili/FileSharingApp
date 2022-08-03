using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingApp.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IFileRepository Files { get; }
        void Save();
    }
}
