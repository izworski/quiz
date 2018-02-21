using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(z => z.HasMany(x => x.Questions).WithOne(x => x.Category).OnDelete(DeleteBehavior.Restrict));
            //builder.Entity<User>(z => z.HasMany(x => x.CreatedQuestions).WithOne(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict));
            builder.Entity<User>(z => z.HasMany(x => x.CreatedCategories).WithOne(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict));

            //var cascadeFKs = builder.Model.GetEntityTypes()
            //                        .SelectMany(t => t.GetForeignKeys())
            //                        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //foreach (var fk in cascadeFKs)
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);
        }
    }
}
