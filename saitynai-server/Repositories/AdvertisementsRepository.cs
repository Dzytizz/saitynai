using saitynai_server.Data;

namespace saitynai_server.Repositories
{
    public interface IAdvertisementsRepository
    {
        Task<List<Advertisement>> GetAllAsync(int gameId);
        Task<Advertisement?> GetAsync(int gameId, int advertisementId);
        Task CreateAsync(Advertisement advertisement);
        Task UpdateAsync(Advertisement advertisement);
        Task DeleteAsync(Advertisement advertisement);
    }

    public class AdvertisementsRepository : IAdvertisementsRepository
    {
        private readonly TablegamesContext _context;

        public AdvertisementsRepository(TablegamesContext context)
        {
            _context = context;
        }

        public async Task<List<Advertisement>> GetAllAsync(int gameId)
        {
            return await _context.Advertisements.Where(o => o.FkGame.Id == gameId).ToListAsync();
        }

        public async Task<Advertisement?> GetAsync(int gameId, int advertisementId)
        {
            return await _context.Advertisements.FirstOrDefaultAsync(o => o.FkGame.Id == gameId && o.Id == advertisementId);
        }

        public async Task CreateAsync(Advertisement advertisement)
        {
            _context.Advertisements.Add(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Advertisement advertisement)
        {
            _context.Advertisements.Update(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Advertisement advertisement)
        {
            _context.Advertisements.Remove(advertisement);
            await _context.SaveChangesAsync();
        }
    }
}
