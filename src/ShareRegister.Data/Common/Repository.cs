using Microsoft.EntityFrameworkCore;
using ShareRegister.Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShareRegister.Data.Common;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public void DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async Task<List<TEntity>> FindAll(Expression<Func<TEntity, bool>> query)
    {
        return await _context.Set<TEntity>().Where(query).ToListAsync();       
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
}
