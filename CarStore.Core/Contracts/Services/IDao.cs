using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Contracts.Services;

public interface IDao<T> where T : class
{
    public Task<List<T>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);
    public Task<object> Insert(T entity);
    public Task Update(T entity);
    public Task DeleteById(int id);
}
