using FileSharingApp.Data.Entities.Identity;
using FileSharingApp.Web.Helpers;
using System.ComponentModel.DataAnnotations;

namespace FileSharingApp.Web.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Fayl" + UIMessages.RequiredMessage)]
        public string Path { get; set; }
        public string ReceivePath { get; set; }
        public string SenderId { get; set; }
        public User User { get; set; }
    }
}
