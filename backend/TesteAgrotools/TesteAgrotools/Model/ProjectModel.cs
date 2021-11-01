using Microsoft.EntityFrameworkCore;
using TesteAgrotools.Entities;

namespace TesteAgrotools.Infrastructure.Model
{
    public class ProjectModel : DbContext
    {
        public ProjectModel() { }

        public ProjectModel(DbContextOptions<ProjectModel> options) : base(options) { }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Form>().HasKey(m => m.ID);
            builder.Entity<FormField>().HasKey(m => m.ID);
            base.OnModelCreating(builder);
        }
    }
}
