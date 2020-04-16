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
    public class AnswerResultBL : IRepository<AnswerResultViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AnswerResultBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<AnswerResult, AnswerResultViewModel>()).CreateMapper();
        }
        public void Create(AnswerResultViewModel answerResultViewModel)
        {
            unitOfWork.AnswerResults.Create(mapper.Map<AnswerResult>(answerResultViewModel));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.AnswerResults.Delete(id);
            unitOfWork.Save();
        }
        public AnswerResultViewModel Read(int id) => mapper.Map<AnswerResultViewModel>(unitOfWork.AnswerResults.Read(id));
        public IEnumerable<AnswerResultViewModel> ReadAll() => mapper.Map<IEnumerable<AnswerResult>, List<AnswerResultViewModel>>(unitOfWork.AnswerResults.ReadAll());
        public void Update(AnswerResultViewModel answerResultViewModel)
        {
            unitOfWork.AnswerResults.Update(mapper.Map<AnswerResult>(answerResultViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
