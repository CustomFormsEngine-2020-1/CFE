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
    public class FormResultBL : IRepository<FormResultViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public FormResultBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<FormResult, FormResultViewModel>()).CreateMapper();
        }
        public void Create(FormResultViewModel formResultViewModel)
        {
            unitOfWork.FormResults.Create(mapper.Map<FormResult>(formResultViewModel));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.FormResults.Delete(id);
            unitOfWork.Save();
        }
        public FormResultViewModel Read(int id) => mapper.Map<FormResultViewModel>(unitOfWork.FormResults.Read(id));
        public IEnumerable<FormResultViewModel> ReadAll() => mapper.Map<IEnumerable<FormResult>, List<FormResultViewModel>>(unitOfWork.FormResults.ReadAll());
        public void Update(FormResultViewModel formResultViewModel)
        {
            unitOfWork.FormResults.Update(mapper.Map<FormResult>(formResultViewModel));
            unitOfWork.Save();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
