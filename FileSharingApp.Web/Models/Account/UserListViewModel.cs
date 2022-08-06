using FileSharingApp.Data.Entities;
using FileSharingApp.Data.Entities.Identity;
using System.Collections.Generic;
namespace FileSharingApp.Web.Models.Account
{
    public class UserListViewModel
    {
        public List<User> Users { get; set; }
        public List<FileModel> Files { get; set; }
    }
}
