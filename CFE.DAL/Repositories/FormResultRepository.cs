using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class FormResultRepository : IRepository<FormResult>
    {
        private ApplicationContext applicationContext;
        public FormResultRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(FormResult formResult)
        {
            if (formResult != null)
                applicationContext.FormResults.Add(formResult);
        }

        public void Delete(int id)
        {
            FormResult formResult = applicationContext.FormResults.Find(id);
            if (formResult != null)
                applicationContext.FormResults.Remove(formResult);
        }

        public int GetId(FormResult formResult)
        {
            int negativeResult = -1;
            if (formResult != null)
            {
                return applicationContext.FormResults.FirstOrDefault(i => i.DTResult == formResult.DTResult &&
                                                                          i.FormId == formResult.FormId &&
                                                                          i.UserId == formResult.UserId).Id;
            }
            return negativeResult;
        }

        public FormResult Read(int id) => applicationContext.FormResults.Find(id) ?? new FormResult();
        public IEnumerable<FormResult> ReadAll() => applicationContext.FormResults.ToList() ?? new List<FormResult>();

        public void Update(FormResult formResult)
        {
            var previousFormResult = applicationContext.FormResults.Find(formResult.Id);
            if (previousFormResult != null)
            {
                applicationContext.FormResults.Remove(previousFormResult);
                FormResult newFormResult = new FormResult()
                {
                    DTResult = formResult.DTResult,
                    FormId = formResult.FormId,
                    UserId = formResult.UserId
                };

                applicationContext.FormResults.Add(newFormResult);
            }
        }
    }
}
