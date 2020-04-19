﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ReadAll();
        T Read(int id);
        int GetId(T item);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
