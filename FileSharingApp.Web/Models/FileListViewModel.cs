using FileSharingApp.Data.Entities;
using FileSharingApp.Data.Entities.Identity;
using System.Collections.Generic;

namespace FileSharingApp.Web.Models
{
    public class FileListViewModel
    {
        public List<File> FileModels { get; set; }
        public List<User> Users { get; set; }
    }
}
