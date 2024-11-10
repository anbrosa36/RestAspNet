using Microsoft.EntityFrameworkCore;
using RestApplication.Model.Base;
using RestApplication.Model.Context;

namespace RestApplication.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private BancoContext _context;
        private DbSet<T> dataSet;

        public GenericRepository(BancoContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();

        }


        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(int id)
        {
            return dataSet.SingleOrDefault(i => i.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(i => i.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            var result = dataSet.SingleOrDefault(i => i.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(int id)
        {
            return dataSet.Any(i => i.Id.Equals(id));
        }
    }
}
