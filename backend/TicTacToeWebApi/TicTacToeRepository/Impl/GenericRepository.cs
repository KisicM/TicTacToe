using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeDomain;

namespace TicTacToeRepository.Impl
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly TicTacToeDbContext _dbContext;

        public GenericRepository(TicTacToeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(T obj)
        {
            try
            {
                _dbContext.Set<T>().Remove(obj);
                Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T Insert(T obj)
        {
            _dbContext.Set<T>().Add(obj);
            Save();
            return obj;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        T IGenericRepository<T>.Update(T obj)
        {
            _dbContext.Set<T>().Update(obj);
            Save();
            return obj;
        }
    }
}
