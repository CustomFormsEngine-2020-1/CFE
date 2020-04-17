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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FormViewModel, Form>()
                    .ForMember("Name", opt => opt.MapFrom(item => item.Name))
                    .ForMember("Description", opt => opt.MapFrom(item => item.Description))
                    .ForMember("DTCreate", opt => opt.MapFrom(item => item.DTCreate))
                    .ForMember("DTStart", opt => opt.MapFrom(item => item.DTStart))
                    .ForMember("DTFinish", opt => opt.MapFrom(item => item.DTFinish))
                    .ForMember("IsPrivate", opt => opt.MapFrom(item => item.IsPrivate))
                    .ForMember("IsAnonymity", opt => opt.MapFrom(item => item.IsAnonymity))
                    .ForMember("IsEditingAfterSaving", opt => opt.MapFrom(src => src.IsEditingAfterSaving)));
            var mapper = new Mapper(config);
            // Выполняем сопоставление
            Form form = mapper.Map<FormViewModel, Form>(formViewModel);
            // Form form = mapper.Map<Form>(formViewModel);
            unitOfWork.Forms.Create(form);
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
