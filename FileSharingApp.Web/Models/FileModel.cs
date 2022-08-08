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
        public string CreatorName { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Fayl" + UIMessages.RequiredMessage)]
        public string Path { get; set; }
        public List<User> SelectedUsers { get; set; }
    }
}
