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
            //Database.EnsureDeleted();
           // Database.EnsureCreated();
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

            // modelBuilder.Entity<Element>().HasData(
            // new Element[]
            // {
            //      new Element { Name = "TextBox", Description = "Однострочный текст" },
            //      new Element { Name = "TextArea", Description = "Многострочный текст" },
            //      new Element { Name = "Number", Description = "Число" },
            //      new Element { Name = "CheckBox", Description = "Множественный выбор" },
            //      new Element { Name = "CheckList", Description = "Список ответов" },
            //      new Element { Name = "RadioButton", Description = "Переключатель - единичный выбор" },
            //      new Element { Name = "DropDown", Description = "Выпадающий список" },
            //      new Element { Name = "DatePicker", Description = "Выбор даты" },
            //      new Element { Name = "TimePicker", Description = "Выбор времени" },
            //      new Element { Name = "MonthCalendar", Description = "Промежуток дат" },
            //      new Element { Name = "File", Description = "Файл" },
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
