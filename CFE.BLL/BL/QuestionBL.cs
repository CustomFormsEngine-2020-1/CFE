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
            if (questionViewModel != null)
            {
                unitOfWork.Questions.Create(MappingQuestionViewModel(questionViewModel));
                unitOfWork.Save(); 
            }
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
            if (questionViewModel != null)
            {
                unitOfWork.Questions.Update(MappingQuestionViewModel(questionViewModel));
                unitOfWork.Save(); 
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public int GetId(QuestionViewModel questionViewModel)
        {
            int negativeResult = -1;
            if (questionViewModel != null)
                return unitOfWork.Questions.GetId(MappingQuestionViewModel(questionViewModel));
            return negativeResult;
        }
        private Question MappingQuestionViewModel(QuestionViewModel questionViewModel)
        {
            Question negativeResult = null;
            if (questionViewModel != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionViewModel, Question>()
                    .ForMember("Name", opt => opt.MapFrom(item => item.Name))
                    .ForMember("FormId", opt => opt.MapFrom(item => item.FormId))
                    .ForMember("ElementId", opt => opt.MapFrom(item => item.ElementId)));
                var mapper = new Mapper(config);
                // Выполняем сопоставление
                return mapper.Map<QuestionViewModel, Question>(questionViewModel);
            }
            return negativeResult;
        }
    }
}
