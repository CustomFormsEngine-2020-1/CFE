﻿using AutoMapper;
using CFE.BLL.DTO;
using CFE.DAL;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class FormBL : IRepository<FormDTO>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public FormBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<Form, FormDTO>()).CreateMapper();
        }
        public void Create(FormDTO formDTO)
        {
            unitOfWork.Forms.Create(mapper.Map<Form>(formDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Forms.Delete(id);
            unitOfWork.Save();
        }
        public FormDTO Read(int id) => mapper.Map<FormDTO>(unitOfWork.Forms.Read(id));
        public IEnumerable<FormDTO> ReadAll() => mapper.Map<IEnumerable<Form>, List<FormDTO>>(unitOfWork.Forms.ReadAll());
        public void Update(FormDTO formDTO)
        {
            unitOfWork.Forms.Update(mapper.Map<Form>(formDTO));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
