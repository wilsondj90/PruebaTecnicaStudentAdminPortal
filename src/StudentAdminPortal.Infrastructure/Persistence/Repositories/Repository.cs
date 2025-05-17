using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentAdminPortal.Domain.Entities;
using StudentAdminPortal.Domain.Interfaces;
using System.Linq.Expressions;

namespace StudentAdminPortal.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<Repository<T>> _logger;

        public Repository(AppDbContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error entidad {entidad}", typeof(T).Name);
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"No existe");
                }

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error entidad: {entidad} Id: {id}", typeof(T).Name, id);
                throw;
            }
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entity = _dbSet.Any(predicate);

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Any");
                throw;
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creando {Entity}", typeof(T).Name);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            try
            {
                _context.Attach(entity).State = EntityState.Modified; 
                _dbSet.Update(entity);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error atualizando {Entity}", typeof(T).Name);
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando {Entity}", typeof(T).Name);
                throw;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error Actualizando {Entity}", typeof(T).Name);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error genericog {Entity}", typeof(T).Name);
                throw;
            }
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
    }
}
