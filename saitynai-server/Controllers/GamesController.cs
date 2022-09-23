using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace saitynai_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly saitynaiContext _context;

        public GamesController(saitynaiContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }
    }
}
