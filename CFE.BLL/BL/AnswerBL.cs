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
    public class AnswerBL : IRepository<AnswerViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AnswerBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<Answer, AnswerViewModel>()).CreateMapper();
        }
        public void Create(AnswerViewModel answerViewModel)
        {
            unitOfWork.Answers.Create(mapper.Map<CFE.Entities.Models.Answer>(answerViewModel));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Answers.Delete(id);
            unitOfWork.Save();
        }
        public AnswerViewModel Read(int id) => mapper.Map<AnswerViewModel>(unitOfWork.Answers.Read(id));
        public IEnumerable<AnswerViewModel> ReadAll() => mapper.Map<IEnumerable<CFE.Entities.Models.Answer>, List<AnswerViewModel>>(unitOfWork.Answers.ReadAll());
        public void Update(AnswerViewModel answerViewModel)
        {
            unitOfWork.Answers.Update(mapper.Map<CFE.Entities.Models.Answer>(answerViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
