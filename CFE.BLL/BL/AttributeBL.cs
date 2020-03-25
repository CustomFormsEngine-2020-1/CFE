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
    public class AttributeBL : IRepository<AttributeDTO>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AttributeBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<CFE.Entities.Models.Attribute, AttributeDTO>()).CreateMapper();
        }
        public void Create(AttributeDTO attributeDTO)
        {
            unitOfWork.Attributes.Create(mapper.Map<CFE.Entities.Models.Attribute>(attributeDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Attributes.Delete(id);
            unitOfWork.Save();
        }
        public AttributeDTO Read(int id) => mapper.Map<AttributeDTO>(unitOfWork.Attributes.Read(id));
        public IEnumerable<AttributeDTO> ReadAll() => mapper.Map<IEnumerable<CFE.Entities.Models.Attribute>, List<AttributeDTO>>(unitOfWork.Attributes.ReadAll());
        public void Update(AttributeDTO attributeDTO)
        {
            unitOfWork.Attributes.Update(mapper.Map<CFE.Entities.Models.Attribute>(attributeDTO));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
