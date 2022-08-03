using FileSharingApp.Data.Entities;
using FileSharingApp.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingApp.Data.Concrete
{
    public class FileDbContext:IdentityDbContext<User>
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {

        }
        public DbSet<File> Files { get; set; }

        
    }
}
