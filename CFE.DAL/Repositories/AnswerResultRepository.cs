using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CFE.DAL.Repositories
{
    public class AnswerResultRepository : IRepository<AnswerResult>
    {
        private ApplicationContext applicationContext;
        public AnswerResultRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(AnswerResult answerResult)
        {
            if (answerResult != null)
                applicationContext.AnswerResults.Add(answerResult);
        }

        public void Delete(int id)
        {
            AnswerResult answerResult = applicationContext.AnswerResults.Find(id);
            if (answerResult != null)
                applicationContext.AnswerResults.Remove(answerResult);
        }

        public int GetId(AnswerResult answerResult)
        {
            int negativeResult = -1;
            if (answerResult != null)
            {
                return applicationContext.AnswerResults.FirstOrDefault(i => i.Value == answerResult.Value &&
                                                                            i.QuestionResultId == answerResult.QuestionResultId).Id;
            }
            return negativeResult;
        }

        public AnswerResult Read(int id) => applicationContext.AnswerResults.Find(id) ?? new AnswerResult();
        public IEnumerable<AnswerResult> ReadAll() => applicationContext.AnswerResults.ToList() ?? new List<AnswerResult>();

        public void Update(AnswerResult answerResult)
        {
            var previousAnswerResult = applicationContext.AnswerResults.Find(answerResult.Id);
            if (previousAnswerResult != null)
            {
                applicationContext.AnswerResults.Remove(previousAnswerResult);
                AnswerResult newAnswerResult = new AnswerResult()
                {
                    Value = answerResult.Value,
                    QuestionResultId = answerResult.QuestionResultId
                };

                applicationContext.AnswerResults.Add(newAnswerResult);
            }
        }
    }
}
