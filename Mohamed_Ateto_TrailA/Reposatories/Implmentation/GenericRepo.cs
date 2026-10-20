using Microsoft.EntityFrameworkCore;
using Mohamed_Ateto_TrailA.Data;
using Mohamed_Ateto_TrailA.Reposatories.Interface;

namespace Mohamed_Ateto_TrailA.Reposatories.Implmentation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> set;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
            this.set = _context.Set<T>();
        }


        public async Task Create(T entity)
        {
                await set.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var item = await set.FindAsync(id);
            set.Remove(item);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await set.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await set.FindAsync(id);
        }

        public async Task Update(int id, T entity)
        {
            var item = await set.FindAsync(id);

             _context.Entry(item).CurrentValues.SetValues(entity);
        }
    }
}
