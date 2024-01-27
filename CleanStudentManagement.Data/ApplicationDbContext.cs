using CleanStudentManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
                
        }
        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<ExamResult> ExamResult { get; set; }
        public DbSet<QnAs> QnAs { get; set; }
        public DbSet<Student> Student { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1, Name="Admin", Password="Admin@123", Role=1, UserName="Admin"
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.HasOne(d => d.Exam)
                .WithMany(p => p.ExamResult)
                .HasForeignKey(x => x.ExamId)
                .HasConstraintName("FK_ExamResult_Exams");

                entity.HasOne(d => d.QnAs)
                .WithMany(p => p.ExamResults)
                .HasForeignKey(x => x.QnAsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamResult_QnAs");

                entity.HasOne(d => d.Student)
                .WithMany(x => x.ExamResults)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Examresult_Users");




            });
        }
    }
}
