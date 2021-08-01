using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Domain.Models;
using Tokenizer.Domain.SeedWork;

namespace Tokenizer.Infra.Repositories
{
    public class MemoryRepository<T>: IRepository<T>
        where T : IEntity
    {
        private List<T> _Items { get; }

        public MemoryRepository()
        {
            _Items = new List<T>();
        }

        public async virtual Task<bool> ValidateEntity(string key)
        {
            var result = await Task.Run<bool>(() => _Items.Count > 0 && _Items.Any(i => i.Key.Equals(key) && i.Validity > DateTime.Now));
            
            return result;
        }

        public async virtual Task<T> UpdateEntity(string key, bool valid)
        {
            var result = await Task.Run<T>(() => _Items.FirstOrDefault<T>(i => i.Key.Equals(key)));

            if (result == null)
            {
                throw new Item_Not_FoundException($"Unable to update. {typeof(T)} is not available with us.");
            }

            if (valid)
                result.Validity = DateTime.Now.AddDays(7);
            else
                result.Validity = DateTime.Now.AddDays(-1);

            return result;
        }

        public async virtual Task<T> AddEntity(T item)
        {
            
            var result = await Task.Run<bool>(() => _Items.Count > 0 && _Items.Any(i => i.Key.Equals(item.Key)));

            if (result)
                throw new Item_ExistException($"Can't add this token. {typeof(T)} already available with us.");
            else
                _Items.Add(item);

            return item;
        }

        public async virtual Task<List<T>> GetListOfEntity(int start, int end)
        {
            if (start < 0)
                start = 0;
            if (end < 0)
                end = _Items.Count;
            if (end > _Items.Count)
                end = _Items.Count;

            var count = end - start;
            var result = await Task.Run<List<T>>(() => _Items.GetRange(start,count));
            return result;
        }
    }
}
