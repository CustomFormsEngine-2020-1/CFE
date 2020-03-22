using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFE.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationContext applicationContext;
        public UserRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public void Create(User user)
        {
            if (user != null)
                applicationContext.Users.Add(user);
        }

        public void Delete(int id)
        {
            User user = applicationContext.Users.Find(id);
            if (user != null)
                applicationContext.Users.Remove(user);
        }

        public User Read(int id) => applicationContext.Users.Find(id) ?? new User(); 
        public IEnumerable<User> ReadAll() => applicationContext.Users.ToList() ?? new List<User>();

        public void Update(User user)
        {
            var previousUser = applicationContext.Users.Find(user.Id);
            if (previousUser != null)
            {
                applicationContext.Users.Remove(previousUser);
                User newUser = new User()
                {
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email
                };

                applicationContext.Users.Add(newUser);
            }
        }
    }
}
