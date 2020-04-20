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
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public void Create(FormViewModel formViewModel)
        {
            if (formViewModel != null)
            {
                // Form form = mapper.Map<Form>(formViewModel);
                unitOfWork.Forms.Create(MappingFormViewModel(formViewModel));
                unitOfWork.Save();
            }
            
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
            if (formViewModel != null)
            {
                // unitOfWork.Forms.Update(mapper.Map<Form>(formViewModel));
                unitOfWork.Forms.Update(MappingFormViewModel(formViewModel));
                unitOfWork.Save(); 
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public int GetId(FormViewModel formViewModel)
        {
            int negativeResult = -1;
            if (formViewModel != null)
                return unitOfWork.Forms.GetId(MappingFormViewModel(formViewModel));
            return negativeResult;
        }

        private Form MappingFormViewModel(FormViewModel formViewModel)
        {
            Form negativeResult = null;
            if (formViewModel != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FormViewModel, Form>()
                    .ForMember("Name", opt => opt.MapFrom(item => item.Name))
                    .ForMember("Description", opt => opt.MapFrom(item => item.Description))
                    .ForMember("DTCreate", opt => opt.MapFrom(item => item.DTCreate))
                    .ForMember("DTStart", opt => opt.MapFrom(item => item.DTStart))
                    .ForMember("DTFinish", opt => opt.MapFrom(item => item.DTFinish))
                    .ForMember("IsPrivate", opt => opt.MapFrom(item => item.IsPrivate))
                    .ForMember("IsAnonymity", opt => opt.MapFrom(item => item.IsAnonymity))
                    .ForMember("IsEditingAfterSaving", opt => opt.MapFrom(src => src.IsEditingAfterSaving))
                    .ForMember("UserId", opt => opt.MapFrom(src => src.UserId)));
                var mapper = new Mapper(config);
                // Выполняем сопоставление
                return mapper.Map<FormViewModel, Form>(formViewModel); 
            }
            return negativeResult;
        }
    }
}
