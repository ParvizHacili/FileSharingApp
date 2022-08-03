using FileSharingApp.Business.Abstract;
using FileSharingApp.Data.Entities;
using FileSharingApp.Data.Entities.Identity;
using FileSharingApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileSharingApp.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IFileService _fileService;
        private UserManager<User> _userManager;
        public AdminController(IFileService fileService, UserManager<User> userManager)
        {
            _fileService = fileService;
            _userManager = userManager;
        }
        public IActionResult FileList()
        {
            var userId = _userManager.GetUserId(User);
            return View(new FileListViewModel()
            {
                FileModels = _fileService.GetFilesByUserId(userId)
            });
        }

        [HttpGet]
        public IActionResult CreateFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFile(FileSharingApp.Data.Entities.File file, IFormFile fromfile)
        {
            if (fromfile == null)
            {
                return View(fromfile);
            }
            var entity = new Data.Entities.File();

            entity.UserId = _userManager.GetUserId(User);
            var extention = Path.GetExtension(fromfile.FileName);
            entity.Name = fromfile.FileName;
            var randomName = string.Format($"{Guid.NewGuid()}{extention}");
            entity.Path = randomName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", randomName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await fromfile.CopyToAsync(stream);
            }

            _fileService.Create(entity);

            return RedirectToAction("FileList");
        }

        [HttpGet]
        public IActionResult EditFile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _fileService.GetById((int)id);

            if (entity == null)
            {
                return NotFound();
            }
            var model = new FileModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Path = entity.Path,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditFile(Data.Entities.File file, IFormFile fromfile)
        {
            var entity = _fileService.GetById(file.Id);
            if (entity == null)
            {
                return NotFound();
            }

            if (fromfile != null)
            {
                var extention = Path.GetExtension(fromfile.FileName);
                entity.Name = fromfile.FileName;
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.Path = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await fromfile.CopyToAsync(stream);
                }
            }

            _fileService.Update(entity);

            return RedirectToAction("FileList");
        }

        [HttpPost]
        public IActionResult DeleteFile(int id)
        {
            var entity = _fileService.GetById(id);
            if (entity != null)
            {
                _fileService.Delete(entity);
            }
            return RedirectToAction("FileList");
        }
    }
}
