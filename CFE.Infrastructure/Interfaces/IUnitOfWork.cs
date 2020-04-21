using CFE.Entities.Models;
using System;

namespace CFE.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository<User> Users { get; }
        IRepository<Form> Forms { get; }
        IRepository<Question> Questions { get; }
        IRepository<Answer> Answers { get; }
        IRepository<Element> Elements { get; }
        IRepository<CFE.Entities.Models.Attribute> Attributes { get; }
        IRepository<FormResult> FormResults { get; }
        IRepository<QuestionResult> QuestionResults { get; }
        IRepository<AnswerResult> AnswerResults { get; }
        IRepository<AttributeResult> AttributeResults { get; }
        void Save();
    }
}
