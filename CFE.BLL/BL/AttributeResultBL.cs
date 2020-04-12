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
    public class AttributeResultBL : IRepository<AttributeResultDTO>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AttributeResultBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<AttributeResult, AttributeResultDTO>()).CreateMapper();
        }
        public void Create(AttributeResultDTO attributeResultDTO)
        {
            unitOfWork.AttributeResults.Create(mapper.Map<AttributeResult>(attributeResultDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.AttributeResults.Delete(id);
            unitOfWork.Save();
        }
        public AttributeResultDTO Read(int id) => mapper.Map<AttributeResultDTO>(unitOfWork.AttributeResults.Read(id));
        public IEnumerable<AttributeResultDTO> ReadAll() => mapper.Map<IEnumerable<AttributeResult>, List<AttributeResultDTO>>(unitOfWork.AttributeResults.ReadAll());
        public void Update(AttributeResultDTO attributeResultDTO)
        {
            unitOfWork.AttributeResults.Update(mapper.Map<AttributeResult>(attributeResultDTO));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
