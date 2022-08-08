using FileSharingApp.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingApp.Data.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CreatorName { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<UserFile> UserFiles { get; set; }        
    }
}
