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
    public class AttributeBL : IRepository<AttributeViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AttributeBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<Attribute, AttributeViewModel>()).CreateMapper();
        }
        public void Create(AttributeViewModel attributeViewModel)
        {
            unitOfWork.Attributes.Create(mapper.Map<CFE.Entities.Models.Attribute>(attributeViewModel));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Attributes.Delete(id);
            unitOfWork.Save();
        }
        public AttributeViewModel Read(int id) => mapper.Map<AttributeViewModel>(unitOfWork.Attributes.Read(id));
        public IEnumerable<AttributeViewModel> ReadAll() => mapper.Map<IEnumerable<CFE.Entities.Models.Attribute>, List<AttributeViewModel>>(unitOfWork.Attributes.ReadAll());
        public void Update(AttributeViewModel attributeViewModel)
        {
            unitOfWork.Attributes.Update(mapper.Map<CFE.Entities.Models.Attribute>(attributeViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
