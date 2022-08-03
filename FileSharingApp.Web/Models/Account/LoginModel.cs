using FileSharingApp.Web.Helpers;
using System.ComponentModel.DataAnnotations;

namespace FileSharingApp.Web.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-Mail" + UIMessages.RequiredMessage)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə" + UIMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
