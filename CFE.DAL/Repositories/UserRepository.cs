using CFE.DAL.Context;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CFE.DAL.Repositories
{
    public class UserRepository : IUserRepository<User>
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

        public void Delete(string id)
        {
            User user = applicationContext.Users.Find(id);
            if (user != null)
                applicationContext.Users.Remove(user);
        }

        public string GetId(User user)
        {
            string negativeResult = null;
            if (user != null)
            {
                //return applicationContext.Users.FirstOrDefault(i => i.Login == user.Login &&
                //                                                    i.Password == user.Password &&
                //                                                    i.Email == user.Email).Id;
                return applicationContext.Users.FirstOrDefault(i => i.Password == user.Password && i.Email == user.Email).Id;
            }
            return negativeResult;
        }

        public User Read(string id) => applicationContext.Users.Find(id) ?? new User();
        public IEnumerable<User> ReadAll() => applicationContext.Users.ToList() ?? new List<User>();

        public void Update(User user)
        {
            var previousUser = applicationContext.Users.Find(user.Id);
            if (previousUser != null)
            {
                applicationContext.Users.Remove(previousUser);
                User newUser = new User()
                {
                    // Login = user.Login,
                    Password = user.Password,
                    Email = user.Email
                };

                applicationContext.Users.Add(newUser);
            }
        }
    }
}
