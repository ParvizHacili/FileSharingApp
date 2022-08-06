using FileSharingApp.Data.Entities;
using FileSharingApp.Data.Entities.Identity;
using FileSharingApp.Web.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
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

        //public User User { get; set; }
        public List<User> SelectedUsers { get; set; }
       // public List<User> Users { get; set; }
       // public List<SelectListItem> selectListUsers { get; set; } 
        public List<UserFile> UserFiles { get; set; }
    }
}
