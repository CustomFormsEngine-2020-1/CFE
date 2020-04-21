using AutoMapper;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;

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
        }
        public void Create(QuestionViewModel questionViewModel)
        {
            if (questionViewModel != null)
            {
                unitOfWork.Questions.Create(mapper.Map<Question>(questionViewModel));
                // unitOfWork.Questions.Create(MappingQuestionViewModel(questionViewModel));
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
                unitOfWork.Questions.Update(mapper.Map<Question>(questionViewModel));
                // unitOfWork.Questions.Update(MappingQuestionViewModel(questionViewModel));
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
                return unitOfWork.Questions.GetId(mapper.Map<Question>(questionViewModel));
            // return unitOfWork.Questions.GetId(MappingQuestionViewModel(questionViewModel));
            return negativeResult;
        }
        // private Question MappingQuestionViewModel(QuestionViewModel questionViewModel)
        // {
        //     Question negativeResult = null;
        //     if (questionViewModel != null)
        //     {
        //         var config = new MapperConfiguration(cfg => cfg.CreateMap<QuestionViewModel, Question>()
        //             .ForMember("Name", opt => opt.MapFrom(item => item.Name))
        //             .ForMember("FormId", opt => opt.MapFrom(item => item.FormId))
        //             .ForMember("ElementId", opt => opt.MapFrom(item => item.ElementId)));
        //         var mapper = new Mapper(config);
        //         // Выполняем сопоставление
        //         return mapper.Map<QuestionViewModel, Question>(questionViewModel);
        //     }
        //     return negativeResult;
        // }
    }
}
