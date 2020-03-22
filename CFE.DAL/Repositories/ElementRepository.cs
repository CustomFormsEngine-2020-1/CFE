﻿using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class ElementRepository : IRepository<Element>
    {
        private ApplicationContext applicationContext;
        public ElementRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(Element element)
        {
            if (element != null)
                applicationContext.Elements.Add(element);
        }

        public void Delete(int id)
        {
            Element element = applicationContext.Elements.Find(id);
            if (element != null)
                applicationContext.Elements.Remove(element);
        }

        public Element Read(int id) => applicationContext.Elements.Find(id) ?? new Element();
        public IEnumerable<Element> ReadAll() => applicationContext.Elements.ToList() ?? new List<Element>();

        public void Update(Element element)
        {
            var previousElement = applicationContext.Elements.Find(element.Id);
            if (previousElement != null)
            {
                applicationContext.Elements.Remove(previousElement);
                Element newElement = new Element()
                {
                    Name = element.Name,
                    Description = element.Description
                };

                applicationContext.Elements.Add(newElement);
            }
        }
    }
}