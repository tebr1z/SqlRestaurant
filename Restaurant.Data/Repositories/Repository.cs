using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Data.Interfaces;
using System.Linq.Expressions;

namespace Restaurant.Data.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected RestaurantDbContext _context { get; }
    protected DbSet<T> _table { get; }

    public Repository()
    {
        _context = new();
        _table = _context.Set<T>();
    }

    public void Add(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public IEnumerable<T> Get(Expression<Func<T, bool>>? expression = null) => expression is not null ? _table.AsNoTracking().Where(expression) : _table.AsNoTracking();

    public void Update(T entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
    }   
}
