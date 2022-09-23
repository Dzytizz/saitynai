using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace saitynai_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetAll()
        {
            var games = await _gamesRepository.GetAsync();
            return games;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            var game = await _gamesRepository.GetAsync(id);
            if (game == null) return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> Post(Game game)
        {
            await _gamesRepository.InsertAsync(game);
            return Created($"/api/games/{game.Id}", game);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> Put(int id, Game game)
        {
            var currentGame = await _gamesRepository.GetAsync(id);
            if (currentGame == null) return NotFound();

            await _gamesRepository.UpdateAsync(game);

            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var currentGame = await _gamesRepository.GetAsync(id);
            if (currentGame == null) return NotFound();

            await _gamesRepository.DeleteAsync(currentGame);

            return NoContent();
        }
    }
}
