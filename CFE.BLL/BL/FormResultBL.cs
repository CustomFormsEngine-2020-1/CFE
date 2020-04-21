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
        }
        public void Create(FormResultViewModel formResultViewModel)
        {
            if (formResultViewModel != null)
            {
                unitOfWork.FormResults.Create(mapper.Map<FormResult>(formResultViewModel));
                // unitOfWork.FormResults.Create(MappingFormResultViewModel(formResultViewModel));
                unitOfWork.Save(); 
            }
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
            if (formResultViewModel != null)
            {
                unitOfWork.FormResults.Update(mapper.Map<FormResult>(formResultViewModel));
                // unitOfWork.FormResults.Update(MappingFormResultViewModel(formResultViewModel));
                unitOfWork.Save(); 
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public int GetId(FormResultViewModel formResultViewModel)
        {
            int negativeResult = -1;
            if (formResultViewModel != null)
                return unitOfWork.FormResults.GetId(mapper.Map<FormResult>(formResultViewModel));
                // return unitOfWork.FormResults.GetId(MappingFormResultViewModel(formResultViewModel));
            return negativeResult;
        }
        // private FormResult MappingFormResultViewModel(FormResultViewModel formResultViewModel)
        // {
        //     FormResult negativeResult = null;
        //     if (formResultViewModel != null)
        //     {
        //         var config = new MapperConfiguration(cfg => cfg.CreateMap<FormResultViewModel, FormResult>()
        //             .ForMember("DTResult", opt => opt.MapFrom(item => item.DTResult))
        //             .ForMember("FormId", opt => opt.MapFrom(item => item.FormId))
        //             .ForMember("UserId", opt => opt.MapFrom(item => item.UserId)));
        //         var mapper = new Mapper(config);
        //         // Выполняем сопоставление
        //         return mapper.Map<FormResultViewModel, FormResult>(formResultViewModel);
        //     }
        //     return negativeResult;
        // }
    }
}
