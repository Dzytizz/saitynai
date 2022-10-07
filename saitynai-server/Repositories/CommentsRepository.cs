namespace saitynai_server.Repositories
{
    public interface ICommentsRepository
    {
        public Task<List<Comment>> GetAllAsync(int advertisementId);
        public Task<Comment?> GetAsync(int advertisementId, int commentId);
        public Task CreateAsync(Comment comment);
        public Task UpdateAsync(Comment comment);
        public Task DeleteAsync(Comment comment);

    }

    public class CommentsRepository : ICommentsRepository
    {
        private readonly saitynaiContext _context;

        public CommentsRepository(saitynaiContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync(int advertisementId)
        {
            return await _context.Comments.Where(o => o.FkAdvertisementId == advertisementId).ToListAsync();
        }

        public async Task<Comment?> GetAsync(int advertisementId, int commentId)
        {
            return await _context.Comments.FirstOrDefaultAsync(o => o.FkAdvertisementId == advertisementId && o.Id == commentId);
        }

        public async Task CreateAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
