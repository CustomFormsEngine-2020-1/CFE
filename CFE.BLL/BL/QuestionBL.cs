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
    public class QuestionBL : IRepository<QuestionDTO>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public QuestionBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<Question, QuestionDTO>()).CreateMapper();
        }
        public void Create(QuestionDTO questionDTO)
        {
            unitOfWork.Questions.Create(mapper.Map<Question>(questionDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Questions.Delete(id);
            unitOfWork.Save();
        }
        public QuestionDTO Read(int id) => mapper.Map<QuestionDTO>(unitOfWork.Questions.Read(id));
        public IEnumerable<QuestionDTO> ReadAll() => mapper.Map<IEnumerable<Question>, List<QuestionDTO>>(unitOfWork.Questions.ReadAll());
        public void Update(QuestionDTO questionDTO)
        {
            unitOfWork.Questions.Update(mapper.Map<Question>(questionDTO));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
