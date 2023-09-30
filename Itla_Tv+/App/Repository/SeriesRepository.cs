using DataBase.Contexts;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repository
{
   public class SeriesRepository
    {
        private readonly AppContexts _dbcontext;

        public SeriesRepository(AppContexts dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Series serie)
        {
            await _dbcontext.Series.AddAsync(serie);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UdapteAsync(Series serie)
        {
            _dbcontext.Entry(serie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Series serie)
        {
            _dbcontext.Set<Series>().Remove(serie);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Series> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Series>().FindAsync(id);

        }

        public async Task<List<Series>> GetAllAsync()
        {
            return await _dbcontext.Set<Series>().ToListAsync();

        }

    }
}
