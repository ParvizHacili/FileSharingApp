using FileSharingApp.Data.Entities;
using System.Collections.Generic;

namespace FileSharingApp.Web.Models.Account
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<File> Products { get; set; }
    }
}
