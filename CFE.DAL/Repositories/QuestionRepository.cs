using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private ApplicationContext applicationContext;
        public QuestionRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(Question question)
        {
            if (question != null)
                applicationContext.Questions.Add(question);
        }

        public void Delete(int id)
        {
            Question question = applicationContext.Questions.Find(id);
            if (question != null)
                applicationContext.Questions.Remove(question);
        }

        public int GetId(Question question)
        {
            int negativeResult = -1;
            if (question != null)
            {
                return applicationContext.Questions.FirstOrDefault(i => i.Name == question.Name &&
                                                                        i.FormId == question.FormId &&
                                                                        i.ElementId == question.ElementId).Id;
            }
            return negativeResult;
        }

        public Question Read(int id) => applicationContext.Questions.Find(id) ?? new Question();
        public IEnumerable<Question> ReadAll() => applicationContext.Questions.ToList() ?? new List<Question>();

        public void Update(Question question)
        {
            var previousQuestion = applicationContext.Questions.Find(question.Id);
            if (previousQuestion != null)
            {
                applicationContext.Questions.Remove(previousQuestion);
                Question newQuestion = new Question()
                {
                    Name = question.Name,
                    FormId = question.FormId,
                    ElementId = question.ElementId
                };

                applicationContext.Questions.Add(newQuestion);
            }
        }
    }
}
