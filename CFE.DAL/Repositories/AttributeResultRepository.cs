using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class AttributeResultRepository : IRepository<AttributeResult>
    {
        private ApplicationContext applicationContext;
        public AttributeResultRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(AttributeResult attributeResult)
        {
            if (attributeResult != null)
                applicationContext.AttributeResults.Add(attributeResult);
        }

        public void Delete(int id)
        {
            AttributeResult attributeResult = applicationContext.AttributeResults.Find(id);
            if (attributeResult != null)
                applicationContext.AttributeResults.Remove(attributeResult);
        }

        public int GetId(AttributeResult attributeResult)
        {
            int negativeResult = -1;
            if (attributeResult != null)
            {
                return applicationContext.AttributeResults.FirstOrDefault(i => i.Value == attributeResult.Value &&
                                                                               i.AttributeId == attributeResult.AttributeId).Id;
            }
            return negativeResult;
        }

        public AttributeResult Read(int id) => applicationContext.AttributeResults.Find(id) ?? new AttributeResult();
        public IEnumerable<AttributeResult> ReadAll() => applicationContext.AttributeResults.ToList() ?? new List<AttributeResult>();

        public void Update(AttributeResult attributeResult)
        {
            var previousAttributeResult = applicationContext.AttributeResults.Find(attributeResult.Id);
            if (previousAttributeResult != null)
            {
                applicationContext.AttributeResults.Remove(previousAttributeResult);
                AttributeResult newAttributeResult = new AttributeResult()
                {
                    Value = attributeResult.Value,
                    AttributeId = attributeResult.AttributeId
                };

                applicationContext.AttributeResults.Add(newAttributeResult);
            }
        }
    }
}
