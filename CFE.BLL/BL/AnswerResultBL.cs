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
            if (answerResultViewModel != null)
            {
                unitOfWork.AnswerResults.Create(mapper.Map<AnswerResult>(answerResultViewModel));
                unitOfWork.Save();
            }
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
            if (answerResultViewModel != null)
            {
                unitOfWork.AnswerResults.Update(MappingAnswerResultViewModel(answerResultViewModel));
                unitOfWork.Save();
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public int GetId(AnswerResultViewModel answerResultViewModel)
        {
            int negativeResult = -1;
            if (answerResultViewModel != null)
                return unitOfWork.AnswerResults.GetId(MappingAnswerResultViewModel(answerResultViewModel));
            return negativeResult;
        }
        private AnswerResult MappingAnswerResultViewModel(AnswerResultViewModel answerResultViewModel)
        {
            AnswerResult negativeResult = null;
            if (answerResultViewModel != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AnswerResultViewModel, AnswerResult>()
                    .ForMember("Value", opt => opt.MapFrom(item => item.Value))
                    .ForMember("QuestionResultId", opt => opt.MapFrom(item => item.QuestionResultId)));
                var mapper = new Mapper(config);
                // Выполняем сопоставление
                return mapper.Map<AnswerResultViewModel, AnswerResult>(answerResultViewModel);
            }
            return negativeResult;
        }
    }
}
