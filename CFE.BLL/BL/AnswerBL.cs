using AutoMapper;
using CFE.BLL.DTO;
using CFE.DAL;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class AnswerBL : IRepository<AnswerDTO>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AnswerBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<Answer, AnswerDTO>()).CreateMapper();
        }
        public void Create(AnswerDTO answerDTO)
        {
            unitOfWork.Answers.Create(mapper.Map<Answer>(answerDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Answers.Delete(id);
            unitOfWork.Save();
        }
        public AnswerDTO Read(int id) => mapper.Map<AnswerDTO>(unitOfWork.Answers.Read(id));
        public IEnumerable<AnswerDTO> ReadAll() => mapper.Map<IEnumerable<Answer>, List<AnswerDTO>>(unitOfWork.Answers.ReadAll());
        public void Update(AnswerDTO answerDTO)
        {
            unitOfWork.Answers.Update(mapper.Map<Answer>(answerDTO));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
