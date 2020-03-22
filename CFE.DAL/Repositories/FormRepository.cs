using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class FormRepository : IRepository<Form>
    {
        private ApplicationContext applicationContext;
        public FormRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(Form form)
        {
            if (form != null)
                applicationContext.Forms.Add(form);
        }

        public void Delete(int id)
        {
            Form form = applicationContext.Forms.Find(id);
            if (form != null)
                applicationContext.Forms.Remove(form);
        }

        public Form Read(int id) => applicationContext.Forms.Find(id) ?? new Form();
        public IEnumerable<Form> ReadAll() => applicationContext.Forms.ToList() ?? new List<Form>();

        public void Update(Form form)
        {
            var previousForm = applicationContext.Forms.Find(form.Id);
            if (previousForm != null)
            {
                applicationContext.Forms.Remove(previousForm);
                Form newForm = new Form()
                {
                    Name = form.Name,
                    Description = form.Description,
                    DTCreate = form.DTCreate,
                    DTStart = form.DTStart,
                    DTFinish = form.DTFinish,
                    IsPrivate = form.IsPrivate,
                    IsAnonymity = form.IsAnonymity,
                    IsEditingAfterSaving = form.IsEditingAfterSaving,
                    UserId = form.UserId
                };

                applicationContext.Forms.Add(newForm);
            }
        }
    }
}
