using AutoMapper;
using CFE.BLL.DTO;
using CFE.DAL;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class QuestionBL : IRepository<QuestionViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public QuestionBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<Question, QuestionViewModel>()).CreateMapper();
        }
        public void Create(QuestionViewModel questionViewModel)
        {
            unitOfWork.Questions.Create(mapper.Map<Question>(questionViewModel));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Questions.Delete(id);
            unitOfWork.Save();
        }
        public QuestionViewModel Read(int id) => mapper.Map<QuestionViewModel>(unitOfWork.Questions.Read(id));
        public IEnumerable<QuestionViewModel> ReadAll() => mapper.Map<IEnumerable<Question>, List<QuestionViewModel>>(unitOfWork.Questions.ReadAll());
        public void Update(QuestionViewModel questionViewModel)
        {
            unitOfWork.Questions.Update(mapper.Map<Question>(questionViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
