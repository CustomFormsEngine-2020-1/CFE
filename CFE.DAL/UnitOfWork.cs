using CFE.DAL.Context;
using CFE.DAL.Repositories;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext applicationContext;
        private UserRepository userRepository;
        private FormRepository formRepository;
        private QuestionRepository questionRepository;
        private AnswerRepository answerRepository;
        private ElementRepository elementRepository;
        private AttributeRepository attributeRepository;
        private FormResultRepository formResultRepository;
        private QuestionResultRepository questionResultRepository;
        private AnswerResultRepository answerResultRepository;
        private AttributeResultRepository attributeResultRepository;
        public UnitOfWork()
        {
            applicationContext = new ApplicationContext();
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(applicationContext);
                return userRepository;
            }
        }
        public IRepository<Form> Forms
        {
            get
            {
                if (formRepository == null)
                    formRepository = new FormRepository(applicationContext);
                return formRepository;
            }
        }
        public IRepository<Question> Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(applicationContext);
                return questionRepository;
            }
        }
        public IRepository<Answer> Answers
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new AnswerRepository(applicationContext);
                return answerRepository;
            }
        }
        public IRepository<Element> Elements
        {
            get
            {
                if (elementRepository == null)
                    elementRepository = new ElementRepository(applicationContext);
                return elementRepository;
            }
        }
        public IRepository<Entities.Models.Attribute> Attributes
        {
            get
            {
                if (attributeRepository == null)
                    attributeRepository = new AttributeRepository(applicationContext);
                return attributeRepository;
            }
        }
        public IRepository<FormResult> FormResults
        {
            get
            {
                if (formResultRepository == null)
                    formResultRepository = new FormResultRepository(applicationContext);
                return formResultRepository;
            }
        }
        public IRepository<QuestionResult> QuestionResults
        {
            get
            {
                if (questionResultRepository == null)
                    questionResultRepository = new QuestionResultRepository(applicationContext);
                return questionResultRepository;
            }
        }
        public IRepository<AnswerResult> AnswerResults
        {
            get
            {
                if (answerResultRepository == null)
                    answerResultRepository = new AnswerResultRepository(applicationContext);
                return answerResultRepository;
            }
        }
        public IRepository<AttributeResult> AttributeResults
        {
            get
            {
                if (attributeResultRepository == null)
                    attributeResultRepository = new AttributeResultRepository(applicationContext);
                return attributeResultRepository;
            }
        }
        public void Dispose()
        {
            applicationContext.Dispose();
        }
        public void Save()
        {
            applicationContext.SaveChanges();
        }
    }
}
