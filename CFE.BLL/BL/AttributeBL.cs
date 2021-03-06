using AutoMapper;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;

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
        }
        public void Create(AttributeViewModel attributeViewModel)
        {
            if (attributeViewModel != null)
            {
                unitOfWork.Attributes.Create(mapper.Map<CFE.Entities.Models.Attribute>(attributeViewModel));
                // unitOfWork.Attributes.Create(MappingAttributeViewModel(attributeViewModel));
                unitOfWork.Save();
            }
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
            if (attributeViewModel != null)
            {
                unitOfWork.Attributes.Update(mapper.Map<CFE.Entities.Models.Attribute>(attributeViewModel));
                // unitOfWork.Attributes.Update(MappingAttributeViewModel(attributeViewModel));
                unitOfWork.Save();
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public int GetId(AttributeViewModel attributeViewModel)
        {
            int negativeResult = -1;
            if (attributeViewModel != null)
                return unitOfWork.Attributes.GetId(mapper.Map<CFE.Entities.Models.Attribute>(attributeViewModel));
            // return unitOfWork.Attributes.GetId(MappingAttributeViewModel(attributeViewModel));
            return negativeResult;
        }
        // private CFE.Entities.Models.Attribute MappingAttributeViewModel(AttributeViewModel attributeViewModel)
        // {
        //     CFE.Entities.Models.Attribute negativeResult = null;
        //     if (attributeViewModel != null)
        //     {
        //         var config = new MapperConfiguration(cfg => cfg.CreateMap<AttributeViewModel, CFE.Entities.Models.Attribute>()
        //             .ForMember("Name", opt => opt.MapFrom(item => item.Name))
        //             .ForMember("DisplayName", opt => opt.MapFrom(item => item.DisplayName))
        //             .ForMember("ElementId", opt => opt.MapFrom(item => item.ElementId)));
        //         var mapper = new Mapper(config);
        //         // Выполняем сопоставление
        //         return mapper.Map<AttributeViewModel, CFE.Entities.Models.Attribute>(attributeViewModel);
        //     }
        //     return negativeResult;
        // }
    }
}
