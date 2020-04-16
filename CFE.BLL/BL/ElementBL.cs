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
    public class ElementBL : IRepository<ElementViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public ElementBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<Element, ElementViewModel>()).CreateMapper();
        }
        public void Create(ElementViewModel elementViewModel)
        {
            unitOfWork.Elements.Create(mapper.Map<Element>(elementViewModel));
            unitOfWork.Save();
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
            unitOfWork.Elements.Update(mapper.Map<Element>(elementViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
