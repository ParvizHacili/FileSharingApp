using FileSharingApp.Business.Abstract;
using FileSharingApp.Data.Entities.Identity;
using FileSharingApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FileSharingApp.Web.Controllers
{
    public class FileController : Controller
    {
        private IFileService _fileService;
        private UserManager<User> _userManager;
        public FileController(IFileService fileService, UserManager<User> userManager)
        {
            _fileService = fileService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            return View(new FileListViewModel()
            {
                FileModels = _fileService.GetFilesByUserId(userId)
            });
        }
    }
}
