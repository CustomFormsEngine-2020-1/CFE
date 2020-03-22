using AutoMapper;
using CFE.BLL.DTO;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class FormResultBL : IRepository<FormResultDTO>
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public FormResultBL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = new MapperConfiguration(config => config.CreateMap<FormResult, FormResultDTO>()).CreateMapper();
        }
        public void Create(FormResultDTO formResultDTO)
        {
            unitOfWork.FormResults.Create(mapper.Map<FormResult>(formResultDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.FormResults.Delete(id);
            unitOfWork.Save();
        }
        public FormResultDTO Read(int id) => mapper.Map<FormResultDTO>(unitOfWork.FormResults.Read(id));
        public IEnumerable<FormResultDTO> ReadAll() => mapper.Map<IEnumerable<FormResult>, List<FormResultDTO>>(unitOfWork.FormResults.ReadAll());
        public void Update(FormResultDTO formResultDTO)
        {
            unitOfWork.FormResults.Update(mapper.Map<FormResult>(formResultDTO));
            unitOfWork.Save();
        }
    }
}
