using AutoMapper;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;

namespace CFE.BLL.BL
{
    public class AnswerBL : IRepository<AnswerViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AnswerBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public void Create(AnswerViewModel answerViewModel)
        {
            if (answerViewModel != null)
            {
                // unitOfWork.Answers.Create(MappingAnswerViewModel(answerViewModel));
                unitOfWork.Answers.Create(mapper.Map<Answer>(answerViewModel));
                unitOfWork.Save();
            }
        }
        public void Delete(int id)
        {
            unitOfWork.Answers.Delete(id);
            unitOfWork.Save();
        }
        public AnswerViewModel Read(int id) => mapper.Map<AnswerViewModel>(unitOfWork.Answers.Read(id));
        public IEnumerable<AnswerViewModel> ReadAll() => mapper.Map<IEnumerable<Answer>, List<AnswerViewModel>>(unitOfWork.Answers.ReadAll());
        public void Update(AnswerViewModel answerViewModel)
        {
            if (answerViewModel != null)
            {
                // unitOfWork.Answers.Update(MappingAnswerViewModel(answerViewModel));
                unitOfWork.Answers.Update(mapper.Map<Answer>(answerViewModel));
                unitOfWork.Save();
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public int GetId(AnswerViewModel answerViewModel)
        {
            int negativeResult = -1;
            if (answerViewModel != null)
                return unitOfWork.Answers.GetId(mapper.Map<Answer>(answerViewModel));
            // return unitOfWork.Answers.GetId(MappingAnswerViewModel(answerViewModel));
            return negativeResult;
        }
        // private Answer MappingAnswerViewModel(AnswerViewModel answerViewModel)
        // {
        //     Answer negativeResult = null;
        //     if (answerViewModel != null)
        //     {
        //         var config = new MapperConfiguration(cfg => cfg.CreateMap<AnswerViewModel, Answer>()
        //             .ForMember("Name", opt => opt.MapFrom(item => item.Name))
        //             .ForMember("QuestionId", opt => opt.MapFrom(item => item.QuestionId)));
        //         var mapper = new Mapper(config);
        //         // Выполняем сопоставление
        //         return mapper.Map<AnswerViewModel, Answer>(answerViewModel);
        //     }
        //     return negativeResult;
        // }
    }
}
