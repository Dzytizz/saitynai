namespace saitynai_server.Repositories
{
    public interface IGamesRepository
    {
        Task<List<Game>> GetAsync();
        Task<Game> GetAsync(int id);
        Task InsertAsync(Game game);
        Task UpdateAsync(Game game);
        Task DeleteAsync(Game game);
    }

    public class GamesRepository : IGamesRepository
    {
        private readonly saitynaiContext _context;

        public GamesRepository(saitynaiContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(o => o.Id.Equals(id));
        }

        public async Task InsertAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Game game)
        {
            _context.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}
