using AutoMapper;
using CFE.BLL.DTO;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    class QuestionResultBL : IRepository<QuestionResultDTO>
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public QuestionResultBL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = new MapperConfiguration(config => config.CreateMap<QuestionResult, QuestionResultDTO>()).CreateMapper();
        }
        public void Create(QuestionResultDTO questionResultDTO)
        {
            unitOfWork.QuestionResults.Create(mapper.Map<QuestionResult>(questionResultDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.QuestionResults.Delete(id);
            unitOfWork.Save();
        }
        public QuestionResultDTO Read(int id) => mapper.Map<QuestionResultDTO>(unitOfWork.QuestionResults.Read(id));
        public IEnumerable<QuestionResultDTO> ReadAll() => mapper.Map<IEnumerable<QuestionResult>, List<QuestionResultDTO>>(unitOfWork.QuestionResults.ReadAll());
        public void Update(QuestionResultDTO questionResultDTO)
        {
            unitOfWork.QuestionResults.Update(mapper.Map<QuestionResult>(questionResultDTO));
            unitOfWork.Save();
        }
    }
}
