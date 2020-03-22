using AutoMapper;
using CFE.BLL.DTO;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.BLL.BL
{
    public class UserBL : IRepository<UserDTO>
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public UserBL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = new MapperConfiguration(config => config.CreateMap<User, UserDTO>()).CreateMapper();
        }
        public void Create(UserDTO userDTO)
        {
            unitOfWork.Users.Create(mapper.Map<User>(userDTO));
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            unitOfWork.Users.Delete(id);
            unitOfWork.Save();
        }
        public UserDTO Read(int id) => mapper.Map<UserDTO>(unitOfWork.Users.Read(id));
        public IEnumerable<UserDTO> ReadAll() => mapper.Map<IEnumerable<User>, List<UserDTO>>(unitOfWork.Users.ReadAll());
        public void Update(UserDTO userDTO)
        {
            unitOfWork.Users.Update(mapper.Map<User>(userDTO));
            unitOfWork.Save();
        }
    }
}
