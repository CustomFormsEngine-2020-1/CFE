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
            if (questionResultViewModel != null)
            {
                unitOfWork.QuestionResults.Create(MappingQuestionResultViewModel(questionResultViewModel));
                unitOfWork.Save(); 
            }
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
            if (questionResultViewModel != null)
            {
                unitOfWork.QuestionResults.Update(MappingQuestionResultViewModel(questionResultViewModel));
                unitOfWork.Save(); 
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public int GetId(QuestionResultViewModel questionResultViewModel)
        {
            int negativeResult = -1;
            if (questionResultViewModel != null)
                return unitOfWork.QuestionResults.GetId(MappingQuestionResultViewModel(questionResultViewModel));
            return negativeResult;
        }
        private QuestionResult MappingQuestionResultViewModel(QuestionResultViewModel questionResultViewModel)
        {
            QuestionResult negativeResult = null;
            if (questionResultViewModel != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionResultViewModel, QuestionResult>()
                    .ForMember("FormResultId", opt => opt.MapFrom(item => item.FormResultId))
                    .ForMember("QuestionId", opt => opt.MapFrom(item => item.QuestionId)));
                var mapper = new Mapper(config);
                // Выполняем сопоставление
                return mapper.Map<QuestionResultViewModel, QuestionResult>(questionResultViewModel);
            }
            return negativeResult;
        }
    }
}
