﻿using AutoMapper;
using CFE.BLL.DTO;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    class AnswerResultBL : IRepository<AnswerResultDTO>
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AnswerResultBL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = new MapperConfiguration(config => config.CreateMap<AnswerResult, AnswerResultDTO>()).CreateMapper();
        }
        public void Create(AnswerResultDTO answerResultDTO)
        {
            unitOfWork.AnswerResults.Create(mapper.Map<AnswerResult>(answerResultDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.AnswerResults.Delete(id);
            unitOfWork.Save();
        }
        public AnswerResultDTO Read(int id) => mapper.Map<AnswerResultDTO>(unitOfWork.AnswerResults.Read(id));
        public IEnumerable<AnswerResultDTO> ReadAll() => mapper.Map<IEnumerable<AnswerResult>, List<AnswerResultDTO>>(unitOfWork.AnswerResults.ReadAll());
        public void Update(AnswerResultDTO answerResultDTO)
        {
            unitOfWork.AnswerResults.Update(mapper.Map<AnswerResult>(answerResultDTO));
            unitOfWork.Save();
        }
    }
}