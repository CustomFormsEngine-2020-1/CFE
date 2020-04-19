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
    public class UserBL : IRepository<UserViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public UserBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            // unitOfWork = new UnitOfWork();
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            // mapper = new MapperConfiguration(config => config.CreateMap<User, UserViewModel>()).CreateMapper();
        }
        public void Create(UserViewModel userViewModel)
        {
            if (userViewModel != null)
            {
                unitOfWork.Users.Create(MappingUserViewModel(userViewModel));
                unitOfWork.Save(); 
            }
        }
        public void Delete(int id)
        {
            unitOfWork.Users.Delete(id);
            unitOfWork.Save();
        }
        public UserViewModel Read(int id) => mapper.Map<UserViewModel>(unitOfWork.Users.Read(id));
        public IEnumerable<UserViewModel> ReadAll() => mapper.Map<IEnumerable<User>, List<UserViewModel>>(unitOfWork.Users.ReadAll());
        public void Update(UserViewModel userViewModel)
        {
            if (userViewModel != null)
            {
                unitOfWork.Users.Update(MappingUserViewModel(userViewModel));
                unitOfWork.Save(); 
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public int GetId(UserViewModel userViewModel)
        {
            int negativeResult = -1;
            if (userViewModel != null)
                return unitOfWork.Users.GetId(MappingUserViewModel(userViewModel));
            return negativeResult;
        }
        private User MappingUserViewModel(UserViewModel userViewModel)
        {
            User negativeResult = null;
            if (userViewModel != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, User>()
                    .ForMember("Login", opt => opt.MapFrom(item => item.Login))
                    .ForMember("Password", opt => opt.MapFrom(item => item.Password))
                    .ForMember("Email", opt => opt.MapFrom(item => item.Email)));
                var mapper = new Mapper(config);
                // Выполняем сопоставление
                return mapper.Map<UserViewModel, User>(userViewModel);
            }
            return negativeResult;
        }
    }
}
