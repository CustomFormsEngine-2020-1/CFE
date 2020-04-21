// using CFE.BLL.DTO;
using CFE.DAL;
using CFE.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CFE.Bootstrap.DI
{
    public static class BLServiceCollectionExtensions
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            // services.AddScoped<IRepository<User>, UserRepository>();
            // services.AddScoped<IRepository<Form>, FormRepository>();
            // services.AddScoped<IRepository<Question>, QuestionRepository>();
            // services.AddScoped<IRepository<Answer>, AnswerRepository>();
            // services.AddScoped<IRepository<Element>, ElementRepository>();
            // services.AddScoped<IRepository<Entities.Models.Attribute>, AttributeRepository>();
            // services.AddScoped<IRepository<FormResult>, FormResultRepository>();
            // services.AddScoped<IRepository<QuestionResult>, QuestionResultRepository>();
            // services.AddScoped<IRepository<AnswerResult>, AnswerResultRepository>();
            // services.AddScoped<IRepository<AttributeResult>, AttributeResultRepository>();
            // services.AddScoped<IRepository<UserViewModel>, UserBL>();
            // services.AddScoped<IRepository<FormViewModel>, FormBL>();
            // services.AddScoped<IRepository<QuestionViewModel>, QuestionBL>();
            // services.AddScoped<IRepository<AnswerViewModel>, AnswerBL>();
            // services.AddScoped<IRepository<ElementViewModel>, ElementBL>();
            // services.AddScoped<IRepository<AttributeViewModel>, AttributeBL>();
            // services.AddScoped<IRepository<FormResultViewModel>, FormResultBL>();
            // services.AddScoped<IRepository<QuestionResultViewModel>, QuestionResultBL>();
            // services.AddScoped<IRepository<AnswerResultViewModel>, AnswerResultBL>();
            // services.AddScoped<IRepository<AttributeResultViewModel>, AttributeResultBL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddDbContext<ApplicationContext>();
            return services;
        }
    }
}
