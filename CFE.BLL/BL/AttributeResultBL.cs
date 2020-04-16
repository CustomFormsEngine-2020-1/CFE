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
    public class AttributeResultBL : IRepository<AttributeResultViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public AttributeResultBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<AttributeResult, AttributeResultViewModel>()).CreateMapper();
        }
        public void Create(AttributeResultViewModel attributeResultViewModel)
        {
            unitOfWork.AttributeResults.Create(mapper.Map<AttributeResult>(attributeResultViewModel));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.AttributeResults.Delete(id);
            unitOfWork.Save();
        }
        public AttributeResultViewModel Read(int id) => mapper.Map<AttributeResultViewModel>(unitOfWork.AttributeResults.Read(id));
        public IEnumerable<AttributeResultViewModel> ReadAll() => mapper.Map<IEnumerable<AttributeResult>, List<AttributeResultViewModel>>(unitOfWork.AttributeResults.ReadAll());
        public void Update(AttributeResultViewModel attributeResultViewModel)
        {
            unitOfWork.AttributeResults.Update(mapper.Map<AttributeResult>(attributeResultViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
