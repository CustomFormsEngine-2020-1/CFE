using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class QuestionResultRepository : IRepository<QuestionResult>
    {
        private ApplicationContext applicationContext;
        public QuestionResultRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(QuestionResult questionResult)
        {
            if (questionResult != null)
                applicationContext.QuestionResults.Add(questionResult);
        }

        public void Delete(int id)
        {
            QuestionResult questionResult = applicationContext.QuestionResults.Find(id);
            if (questionResult != null)
                applicationContext.QuestionResults.Remove(questionResult);
        }

        public QuestionResult Read(int id) => applicationContext.QuestionResults.Find(id) ?? new QuestionResult();
        public IEnumerable<QuestionResult> ReadAll() => applicationContext.QuestionResults.ToList() ?? new List<QuestionResult>();

        public void Update(QuestionResult questionResult)
        {
            var previousQuestionResult = applicationContext.QuestionResults.Find(questionResult.Id);
            if (previousQuestionResult != null)
            {
                applicationContext.QuestionResults.Remove(previousQuestionResult);
                QuestionResult newQuestionResult = new QuestionResult()
                {
                    QuestionId = questionResult.QuestionId,
                    FormResultId = questionResult.FormResultId
                };

                applicationContext.QuestionResults.Add(newQuestionResult);
            }
        }
    }
}
