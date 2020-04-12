﻿using CFE.BLL.BL;
using CFE.BLL.DTO;
using CFE.DAL;
using CFE.DAL.Context;
using CFE.DAL.Repositories;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Bootstrap.DI
{
    public static class BLServiceCollectionExtensions
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Form>, FormRepository>();
            services.AddScoped<IRepository<Question>, QuestionRepository>();
            services.AddScoped<IRepository<Answer>, AnswerRepository>();
            services.AddScoped<IRepository<Element>, ElementRepository>();
            services.AddScoped<IRepository<Entities.Models.Attribute>, AttributeRepository>();
            services.AddScoped<IRepository<FormResult>, FormResultRepository>();
            services.AddScoped<IRepository<QuestionResult>, QuestionResultRepository>();
            services.AddScoped<IRepository<AnswerResult>, AnswerResultRepository>();
            services.AddScoped<IRepository<AttributeResult>, AttributeResultRepository>();
            services.AddScoped<IRepository<UserDTO>, UserBL>();
            services.AddScoped<IRepository<FormDTO>, FormBL>();
            services.AddScoped<IRepository<QuestionDTO>, QuestionBL>();
            services.AddScoped<IRepository<AnswerDTO>, AnswerBL>();
            services.AddScoped<IRepository<ElementDTO>, ElementBL>();
            services.AddScoped<IRepository<AttributeDTO>, AttributeBL>();
            services.AddScoped<IRepository<FormResultDTO>, FormResultBL>();
            services.AddScoped<IRepository<QuestionResultDTO>, QuestionResultBL>();
            services.AddScoped<IRepository<AnswerResultDTO>, AnswerResultBL>();
            services.AddScoped<IRepository<AttributeResultDTO>, AttributeResultBL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationContext>();
            return services;
        }
    }
}
