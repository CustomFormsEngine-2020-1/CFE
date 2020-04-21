using AutoMapper;
using CFE.BLL.DTO;
using CFE.DAL;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using CFE.ViewModels.VM.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class UserBL : IUserRepository<UserViewModel>, IDisposable
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public UserBL(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public void Create(UserViewModel userViewModel)
        {
            if (userViewModel != null)
            {
                userViewModel.Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                unitOfWork.Users.Create(mapper.Map<User>(userViewModel));
                unitOfWork.Save(); 
            }
        }
        public void Delete(string id)
        {
            unitOfWork.Users.Delete(id);
            unitOfWork.Save();
        }
        public UserViewModel Read(string id) => mapper.Map<UserViewModel>(unitOfWork.Users.Read(id));
        public IEnumerable<UserViewModel> ReadAll() => mapper.Map<IEnumerable<User>, List<UserViewModel>>(unitOfWork.Users.ReadAll());
        public void Update(UserViewModel userViewModel)
        {
            if (userViewModel != null)
            {
                unitOfWork.Users.Update(mapper.Map<User>(userViewModel));
                unitOfWork.Save(); 
            }
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
        public string GetId(UserViewModel userViewModel)
        {
            string negativeResult = null;

            if (userViewModel != null)
            {
                return unitOfWork.Users.GetId(mapper.Map<User>(userViewModel));
            }
            return negativeResult;
        }
       
    }
}
