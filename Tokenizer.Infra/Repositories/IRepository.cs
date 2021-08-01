using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Domain.Models;

namespace Tokenizer.Infra.Repositories
{
    public interface IRepository<T>
        where T : IEntity
    {
        Task<bool> ValidateEntity(string key);
        Task<T> UpdateEntity(string key, bool valid);
        Task<T> AddEntity(T item);
        Task<List<T>> GetListOfEntity(int start, int end);
    }
}
