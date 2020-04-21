using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private ApplicationContext applicationContext;
        public AnswerRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(Answer answer)
        {
            if (answer != null)
                applicationContext.Answers.Add(answer);
        }

        public void Delete(int id)
        {
            Answer answer = applicationContext.Answers.Find(id);
            if (answer != null)
                applicationContext.Answers.Remove(answer);
        }

        public int GetId(Answer answer)
        {
            int negativeResult = -1;
            if (answer != null)
            {
                return answer.Id;
                // return applicationContext.Answers.FirstOrDefault(i => i.Name == answer.Name &&
                //                                                       i.QuestionId == answer.QuestionId).Id;
            }
            return negativeResult;
        }

        public Answer Read(int id) => applicationContext.Answers.Find(id) ?? new Answer();
        public IEnumerable<Answer> ReadAll() => applicationContext.Answers.ToList() ?? new List<Answer>();

        public void Update(Answer answer)
        {
            var previousAnswer = applicationContext.Answers.Find(answer.Id);
            if (previousAnswer != null)
            {
                applicationContext.Answers.Remove(previousAnswer);
                Answer newAnswer = new Answer()
                {
                    Name = answer.Name,
                    QuestionId = answer.QuestionId
                };

                applicationContext.Answers.Add(newAnswer);
            }
        }
    }
}
