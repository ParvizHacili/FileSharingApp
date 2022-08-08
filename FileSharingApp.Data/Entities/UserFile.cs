using FileSharingApp.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingApp.Data.Entities
{
    public class UserFile
    {
        public string UserId { get; set; }
        public int FileId { get; set; }
        public User User { get; set; }
        public Data.Entities.File File { get; set; }
        public bool IsDeleted { get; set; }
    }
}
