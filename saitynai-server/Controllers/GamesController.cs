using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saitynai_server.Auth.Model;
using saitynai_server.Data.Dtos.Games;
using saitynai_server.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
        {
            var games = await _gamesRepository.GetAllAsync();

            return Ok(games.Select(o => _mapper.Map<GameDto>(o)));
        }

        [HttpGet("{id}")]
        [AuthorizeByRoles(Roles.Admin, Roles.User)]
        public async Task<ActionResult<GameDto>> Get(int id)
        {
            var game = await _gamesRepository.GetAsync(id);
            if (game == null)
                return NotFound($"Game with id '{id}' not found.");

            return Ok(_mapper.Map<GameDto>(game));
        }

        [HttpPost]
        [AuthorizeByRoles(Roles.Admin)]
        public async Task<ActionResult<GameDto>> Create(GamePostDto gamePostDto)
        {
            var game = _mapper.Map<Game>(gamePostDto);
            if (game.Photos == null)
                game.Photos = "default.jpg";

            await _gamesRepository.CreateAsync(game);

            return Created($"/api/v1/games/{game.Id}", _mapper.Map<GameDto>(game));
        }

        [HttpPut("{id}")]
        [AuthorizeByRoles(Roles.Admin)]
        public async Task<ActionResult<GameDto>> Update(int id, GameUpdateDto gameUpdateDto)
        {
            var game = await _gamesRepository.GetAsync(id);
            if (game == null)
                return NotFound($"Game with id '{id}' not found.");

            if (!game.Photos.Equals(gameUpdateDto.Photos))
                FilesController.Delete(game.Photos);

            _mapper.Map(gameUpdateDto, game);
   
            await _gamesRepository.UpdateAsync(game);

            return Ok(_mapper.Map<GameDto>(game));
        }

        [HttpDelete("{id}")]
        [AuthorizeByRoles(Roles.Admin)]
        public async Task<ActionResult> Remove(int id)
        {
            var currentGame = await _gamesRepository.GetAsync(id);
            if (currentGame == null)
                return NotFound($"Game with id '{id}' not found.");

            FilesController.Delete(currentGame.Photos);

            await _gamesRepository.DeleteAsync(currentGame);

            return NoContent();
        }
    }
}