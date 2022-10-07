using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saitynai_server.Data.Dtos.Games;

namespace saitynai_server.Controllers
{
    [Route("api/v1/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGamesRepository _gamesRepository;

        public GamesController(IMapper mapper, IGamesRepository gamesRepository)
        {
            _mapper = mapper;
            _gamesRepository = gamesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
        {
            var games = await _gamesRepository.GetAllAsync();
            //if (!games.Any()) return NotFound($"No games found.");

            return Ok(games.Select(o => _mapper.Map<GameDto>(o)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> Get(int id)
        {
            var game = await _gamesRepository.GetAsync(id);
            if (game == null) 
                return NotFound($"Game with id '{id}' not found.");

            return Ok(_mapper.Map<GameDto>(game));
        }

        [HttpPost]
        public async Task<ActionResult<GameDto>> Create(GamePostDto gamePostDto)
        {
            var game = _mapper.Map<Game>(gamePostDto);
            game.Photos = "default.jpg"; // =========== TEMPORARY ======= should call some function that generates a filename (or filenames)
            
            await _gamesRepository.CreateAsync(game);

            return Created($"/api/v1/games/{game.Id}", _mapper.Map<GameDto>(game));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GameDto>> Update(int id, GameUpdateDto gameUpdateDto)
        {
            var game = await _gamesRepository.GetAsync(id);
            if (game == null) 
                return NotFound($"Game with id '{id}' not found.");

            _mapper.Map(gameUpdateDto, game);
            game.Photos = "default.jpg"; // =========== TEMPORARY ======= should call some function that generates a filename (or filenames)

            await _gamesRepository.UpdateAsync(game);

            return Ok(_mapper.Map<GameDto>(game));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            var currentGame = await _gamesRepository.GetAsync(id);
            if (currentGame == null) 
                return NotFound($"Game with id '{id}' not found.");

            await _gamesRepository.DeleteAsync(currentGame);

            return NoContent();
        }
    }
}