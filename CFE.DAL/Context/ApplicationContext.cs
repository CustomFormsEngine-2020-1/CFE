using CFE.DAL.Configurations;
using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormResult> FormResults { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionResult> QuestionResults { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerResult> AnswerResults { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<CFE.Entities.Models.Attribute> Attributes { get; set; }
        public DbSet<AttributeResult> AttributeResults { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CT9PI34\SQLEXPRESS;Database=CFE.EFCoreDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FormConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new ElementConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new FormResultConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionResultConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerResultConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeResultConfiguration());
        }
    }
}
