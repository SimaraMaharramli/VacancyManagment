using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace SImaraMaharramli_Pasha.Domain
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<UserAnswer>()
         .HasOne(ua => ua.Application)
         .WithMany()
         .HasForeignKey(ua => ua.ApplicationId)
         .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserAnswer>()
                .HasOne(ua => ua.Question)
                .WithMany()
                .HasForeignKey(ua => ua.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserAnswer>()
                .HasOne(ua => ua.Answer)
                .WithMany()
                .HasForeignKey(ua => ua.AnswerId)
                .OnDelete(DeleteBehavior.NoAction);


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<VacancyApplication> Applications { get; set; }
        public DbSet<AppTestResult> TestResults { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
    }
}
