using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Mohamed_Ateto_TrailA.Models;

namespace Mohamed_Ateto_TrailA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<CanditateProfile> CanditateProfiles { get; set; }
        public DbSet<Application> Applications { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
                .HasIndex(s => s.Email)
                .IsUnique();


            modelBuilder.Entity<Application>()
                .HasIndex(s => new { s.CanditaeProfileID, s.JobID })
                .IsUnique();



            modelBuilder.Entity<User>()
                .HasOne(s => s.CanditateProfile)
                .WithOne(s => s.User)
                .HasForeignKey<CanditateProfile>(s => s.UserID)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<User>()
                .HasMany(s => s.Companys)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);




            modelBuilder.Entity<Company>()
                .HasMany(s => s.jobs)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyID)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<CanditateProfile>()
                .HasMany(s => s.Applications)
                .WithOne(s => s.CanditateProfile)
                .HasForeignKey(s => s.CanditaeProfileID)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Job>()
                .HasMany(s => s.Applications)
                .WithOne(s => s.Job)
                .HasForeignKey(s => s.JobID)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<User>()
                .HasData(
                    new User { id = 1 ,FullName = "Ahmed Hassan" , Email ="ahmedhassan@gmail.com", Password = "123456",Role ="Candidate" , CreateAte = new DateTime(2026,09,01)},
                    new User { id = 2 ,FullName = "Sara Mohamed" , Email ="saramohamed@gmail.com", Password = "123456",Role ="Employer" , CreateAte = new DateTime(2026,09,02)},
                    new User { id = 3 ,FullName = "Omer Ali" , Email ="omeradmin@gmail.com", Password = "123456",Role ="Admin" , CreateAte = new DateTime(2025,09,09)},
                    new User { id = 4, FullName = "gilberto mohamed", Email = "gilbertomohamed@gmail.com", Password = "123456", Role = "Candidate", CreateAte = new DateTime(2026, 09, 03) },
                    new User { id = 5, FullName = "Hosame ahmed", Email = "hosame@gmail.com", Password = "123456", Role = "Employer", CreateAte = new DateTime(2026, 09, 04) }


                );


            modelBuilder.Entity<CanditateProfile>()
                .HasData(

                    new CanditateProfile { id = 1, Phone = "01012345678", ResumeURL = "emample.ocm/resume1", Skill = "ASP.NET Core", YearOfExperience = 1, UserID = 1 },
                    new CanditateProfile { id = 2, Phone = "01055556677", ResumeURL = "emample.ocm/resume2", Skill = "Jave", YearOfExperience = 2,  UserID = 4 }

                );


            modelBuilder.Entity<Company>()
                .HasData(
                    new Company { Id = 1 , Name = "Tach Solutions" , Description ="Software company" , WebSite ="https:// techsolutions.example.com" , Location ="Cairo" , UserId = 2},
                    new Company { Id = 2 , Name = "Future System" , Description ="IT consulting" , WebSite ="https:// it.example2.com" , Location ="Giza" , UserId = 5}
                );

            modelBuilder.Entity<Job>()
                .HasData(
                    new Job { Id = 1, Title = "Back End" , Description = "using ASP.NET Core" , Salary = 30000, Location="Cairo" , EmployeeType = "FullTime" , PostedDate = new DateTime(2026,10,01),Deadline = new DateTime(2026, 11, 01) , Status = "Open" , CompanyID=1 },
                    new Job { Id = 2, Title = "Front End" , Description = "Develop Web Interface" , Salary = 25000, Location="Giza" , EmployeeType = "Contract" , PostedDate = new DateTime(2026,10,02),Deadline = new DateTime(2026, 11, 02) , Status = "Open" , CompanyID=2  }

                );

            modelBuilder.Entity<Application>()
                .HasData(
                    new Application { Id = 1, ApplicationDate = new DateTime(2026, 10, 05), Status = "Pending", CoverLetter = " Intersted in backecnd development", CanditaeProfileID = 1, JobID = 1 },
                    new Application { Id = 2, ApplicationDate = new DateTime(2026, 10, 06), Status = "UnderReview", CoverLetter = " Intersted in Front End development", CanditaeProfileID = 2, JobID = 2 }
                );

        }



    }
}
