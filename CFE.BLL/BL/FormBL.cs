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
    public class FormBL : IRepository<FormViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public FormBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<Form, FormViewModel>()).CreateMapper();
        }
        public void Create(FormViewModel formViewModel)
        {
            unitOfWork.Forms.Create(mapper.Map<Form>(formViewModel));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Forms.Delete(id);
            unitOfWork.Save();
        }
        public FormViewModel Read(int id) => mapper.Map<FormViewModel>(unitOfWork.Forms.Read(id));
        public IEnumerable<FormViewModel> ReadAll() => mapper.Map<IEnumerable<Form>, List<FormViewModel>>(unitOfWork.Forms.ReadAll());
        public void Update(FormViewModel formViewModel)
        {
            unitOfWork.Forms.Update(mapper.Map<Form>(formViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
