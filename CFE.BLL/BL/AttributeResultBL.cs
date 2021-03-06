﻿using AutoMapper;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using System;
using System.Collections.Generic;

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
        }
        public void Create(AttributeResultViewModel attributeResultViewModel)
        {
            if (attributeResultViewModel != null)
            {
                unitOfWork.AttributeResults.Create(mapper.Map<AttributeResult>(attributeResultViewModel));
                // unitOfWork.AttributeResults.Create(MappingAttributeResultViewModel(attributeResultViewModel));
                unitOfWork.Save();
            }
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
            if (attributeResultViewModel != null)
            {
                unitOfWork.AttributeResults.Update(mapper.Map<AttributeResult>(attributeResultViewModel));
                // unitOfWork.AttributeResults.Update(MappingAttributeResultViewModel(attributeResultViewModel));
                unitOfWork.Save();
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public int GetId(AttributeResultViewModel attributeResultViewModel)
        {
            int negativeResult = -1;
            if (attributeResultViewModel != null)
                return unitOfWork.AttributeResults.GetId(mapper.Map<AttributeResult>(attributeResultViewModel));
            // return unitOfWork.AttributeResults.GetId(MappingAttributeResultViewModel(attributeResultViewModel));
            return negativeResult;
        }
        // private AttributeResult MappingAttributeResultViewModel(AttributeResultViewModel attributeResultViewModel)
        // {
        //     AttributeResult negativeResult = null;
        //     if (attributeResultViewModel != null)
        //     {
        //         var config = new MapperConfiguration(cfg => cfg.CreateMap<AttributeResultViewModel, AttributeResult>()
        //             .ForMember("Value", opt => opt.MapFrom(item => item.Value))
        //             .ForMember("AttributeId", opt => opt.MapFrom(item => item.AttributeId)));
        //         var mapper = new Mapper(config);
        //         // Выполняем сопоставление
        //         return mapper.Map<AttributeResultViewModel, AttributeResult>(attributeResultViewModel);
        //     }
        //     return negativeResult;
        // }
    }
}
