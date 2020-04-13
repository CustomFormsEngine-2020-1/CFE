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
    public class QuestionResultBL : IRepository<QuestionResultViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public QuestionResultBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<QuestionResult, QuestionResultViewModel>()).CreateMapper();
        }
        public void Create(QuestionResultViewModel questionResultViewModel)
        {
            unitOfWork.QuestionResults.Create(mapper.Map<QuestionResult>(questionResultViewModel));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.QuestionResults.Delete(id);
            unitOfWork.Save();
        }
        public QuestionResultViewModel Read(int id) => mapper.Map<QuestionResultViewModel>(unitOfWork.QuestionResults.Read(id));
        public IEnumerable<QuestionResultViewModel> ReadAll() => mapper.Map<IEnumerable<QuestionResult>, List<QuestionResultViewModel>>(unitOfWork.QuestionResults.ReadAll());
        public void Update(QuestionResultViewModel questionResultViewModel)
        {
            unitOfWork.QuestionResults.Update(mapper.Map<QuestionResult>(questionResultViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
