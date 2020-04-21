using AutoMapper;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;

namespace CFE.BLL.BL
{
    public class ElementBL : IRepository<ElementViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public ElementBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public void Create(ElementViewModel elementViewModel)
        {
            if (elementViewModel != null)
            {
                unitOfWork.Elements.Create(mapper.Map<Element>(elementViewModel));
                // unitOfWork.Elements.Create(MappingElementViewModel(elementViewModel));
                unitOfWork.Save();
            }
        }
        public void Delete(int id)
        {
            unitOfWork.Elements.Delete(id);
            unitOfWork.Save();
        }
        public ElementViewModel Read(int id) => mapper.Map<ElementViewModel>(unitOfWork.Elements.Read(id));
        public IEnumerable<ElementViewModel> ReadAll() => mapper.Map<IEnumerable<Element>, List<ElementViewModel>>(unitOfWork.Elements.ReadAll());
        public void Update(ElementViewModel elementViewModel)
        {
            if (elementViewModel != null)
            {
                unitOfWork.Elements.Update(mapper.Map<Element>(elementViewModel));
                // unitOfWork.Elements.Update(MappingElementViewModel(elementViewModel));
                unitOfWork.Save();
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public int GetId(ElementViewModel elementViewModel)
        {
            int negativeResult = -1;
            if (elementViewModel != null)
                return unitOfWork.Elements.GetId(mapper.Map<Element>(elementViewModel));
            // return unitOfWork.Elements.GetId(MappingElementViewModel(elementViewModel));
            return negativeResult;
        }
        // private Element MappingElementViewModel(ElementViewModel elementViewModel)
        // {
        //     Element negativeResult = null;
        //     if (elementViewModel != null)
        //     {
        //         var config = new MapperConfiguration(cfg => cfg.CreateMap<ElementViewModel, Element>()
        //             .ForMember("Name", opt => opt.MapFrom(item => item.Name))
        //             .ForMember("Description", opt => opt.MapFrom(item => item.Description)));
        //         var mapper = new Mapper(config);
        //         // Выполняем сопоставление
        //         return mapper.Map<ElementViewModel, Element>(elementViewModel);
        //     }
        //     return negativeResult;
        // }
    }
}
