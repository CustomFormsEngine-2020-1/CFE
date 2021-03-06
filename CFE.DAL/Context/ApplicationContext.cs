﻿using CFE.DAL.Configurations;
using CFE.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CFE.DAL.Context
{
    public class ApplicationContext : IdentityDbContext<User>
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

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CFE.EFCoreDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FormConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new ElementConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new FormResultConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionResultConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerResultConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeResultConfiguration());
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Element>().HasData(
            // new Element[]
            // {
            //       new Element { Id = 1, Name = "TextBox", Description = "Однострочный текст" },
            //       new Element { Id = 2, Name = "TextArea", Description = "Многострочный текст" },
            //       new Element { Id = 3, Name = "Number", Description = "Число" },
            //       new Element { Id = 4, Name = "CheckBox", Description = "Множественный выбор" },
            //       new Element { Id = 5, Name = "CheckList", Description = "Список ответов" },
            //       new Element { Id = 6, Name = "RadioButton", Description = "Переключатель - единичный выбор" },
            //       new Element { Id = 7, Name = "DropDown", Description = "Выпадающий список" },
            //       new Element { Id = 8, Name = "DatePicker", Description = "Выбор даты" },
            //       new Element { Id = 9, Name = "TimePicker", Description = "Выбор времени" },
            //       new Element { Id = 10, Name = "MonthCalendar", Description = "Промежуток дат" },
            //       new Element { Id = 11, Name = "File", Description = "Файл" },
            // });

            // modelBuilder.Entity<CFE.Entities.Models.Attribute>().HasData(
            // new CFE.Entities.Models.Attribute[]
            // {
            //      new CFE.Entities.Models.Attribute { Name = "Required", DisplayName = "Обязательное поле" },
            //      new CFE.Entities.Models.Attribute { Name = "MaxValue", DisplayName = "Максимальное значение" },
            //      new CFE.Entities.Models.Attribute { Name = "MinValue", DisplayName = "Минимальное значение" },
            //      new CFE.Entities.Models.Attribute { Name = "Regex", DisplayName = "Регулярное выражение" },
            //      new CFE.Entities.Models.Attribute { Name = "Format", DisplayName = "Формат" },
            //      new CFE.Entities.Models.Attribute { Name = "ExtensionList", DisplayName = "Список расширений" }
            // });
        }
    }
}
