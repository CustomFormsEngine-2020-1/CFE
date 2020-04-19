using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class AttributeRepository : IRepository<CFE.Entities.Models.Attribute>
    {
        private ApplicationContext applicationContext;
        public AttributeRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(CFE.Entities.Models.Attribute attribute)
        {
            if (attribute != null)
                applicationContext.Attributes.Add(attribute);
        }

        public void Delete(int id)
        {
            CFE.Entities.Models.Attribute attribute = applicationContext.Attributes.Find(id);
            if (attribute != null)
                applicationContext.Attributes.Remove(attribute);
        }

        public int GetId(Entities.Models.Attribute attribute)
        {
            int negativeResult = -1;
            if (attribute != null)
            {
                return applicationContext.Attributes.FirstOrDefault(i => i.Name == attribute.Name &&
                                                                         i.DisplayName == attribute.DisplayName &&
                                                                         i.ElementId == attribute.ElementId).Id;
            }
            return negativeResult;
        }

        public CFE.Entities.Models.Attribute Read(int id) => applicationContext.Attributes.Find(id) ?? new CFE.Entities.Models.Attribute();
        public IEnumerable<CFE.Entities.Models.Attribute> ReadAll() => applicationContext.Attributes.ToList() ?? new List<CFE.Entities.Models.Attribute>();

        public void Update(CFE.Entities.Models.Attribute attribute)
        {
            var previousAttribute = applicationContext.Attributes.Find(attribute.Id);
            if (previousAttribute != null)
            {
                applicationContext.Attributes.Remove(previousAttribute);
                CFE.Entities.Models.Attribute newAttribute = new CFE.Entities.Models.Attribute()
                {
                    Name = attribute.Name,
                    DisplayName = attribute.DisplayName,
                    ElementId = attribute.ElementId
                };

                applicationContext.Attributes.Add(newAttribute);
            }
        }
    }
}
