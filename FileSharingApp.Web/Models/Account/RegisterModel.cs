using FileSharingApp.Web.Helpers;
using System.ComponentModel.DataAnnotations;

namespace FileSharingApp.Web.Models.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Ad" + UIMessages.RequiredMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad" + UIMessages.RequiredMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "İstifadəçi Adı" + UIMessages.RequiredMessage)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Mail Adresi" + UIMessages.RequiredMessage)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə" + UIMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrə təkrarı" + UIMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
