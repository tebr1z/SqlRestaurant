using Restaurant.Core.Entities;
using System.Linq.Expressions;

namespace Restaurant.Data.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    IEnumerable<T> Get(Expression<Func<T, bool>>? expression=null);
}
