using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyResumeSite.Models;

namespace MyResumeSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AdminInfo> AdminInfos { get; set; }
        public DbSet<AdminResume> AdminResumes { get; set; }
        public DbSet<AdminResumeSectionTitle> AdminResumeSectionTitles { get; set; }
        public DbSet<SectionTitleDetail> SectionTitleDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
