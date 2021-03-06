﻿using System.Collections.Generic;

namespace CFE.Infrastructure.Interfaces
{
    public interface IUserRepository<T> where T : class
    {

        IEnumerable<T> ReadAll();
        T Read(string id);
        string GetId(T item);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
    }
}
