using AutoMapper;
using CFE.BLL.DTO;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class ElementBL : IRepository<ElementDTO>
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public ElementBL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = new MapperConfiguration(config => config.CreateMap<Element, ElementDTO>()).CreateMapper();
        }
        public void Create(ElementDTO elementDTO)
        {
            unitOfWork.Elements.Create(mapper.Map<Element>(elementDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Elements.Delete(id);
            unitOfWork.Save();
        }
        public ElementDTO Read(int id) => mapper.Map<ElementDTO>(unitOfWork.Elements.Read(id));
        public IEnumerable<ElementDTO> ReadAll() => mapper.Map<IEnumerable<Element>, List<ElementDTO>>(unitOfWork.Elements.ReadAll());
        public void Update(ElementDTO elementDTO)
        {
            unitOfWork.Elements.Update(mapper.Map<Element>(elementDTO));
            unitOfWork.Save();
        }
    }
}
