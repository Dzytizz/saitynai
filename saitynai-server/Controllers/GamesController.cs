using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saitynai_server.Data.Dtos.Games;
using saitynai_server.Helpers;

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
            if (game.Photos == null)
                game.Photos = "default.jpg";

            await _gamesRepository.CreateAsync(game);

            return Created($"/api/v1/games/{game.Id}", _mapper.Map<GameDto>(game));
        }


        //[HttpPost]
        //public async Task<ActionResult<GameDto>> Create([FromForm] MultipleFilesGeneric<GamePostDto> gameFormData)
        //{
        //    string lastFilename = "default.jpg";

        //    if (gameFormData.Files != null && gameFormData.Files.Count > 0)
        //    {
        //        foreach (var file in gameFormData.Files)
        //        {
        //            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        //            //create folder if not exist
        //            if (!Directory.Exists(path))
        //                Directory.CreateDirectory(path);


        //            string fileNameWithPath = Path.Combine(path, file.FileName);

        //            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }

        //            lastFilename = file.FileName;
        //        }
        //    }

        //    var game = _mapper.Map<Game>(gameFormData.Data);
        //    game.Photos = lastFilename;
        //    //game.Photos = "default.jpg"; // =========== TEMPORARY ======= should call some function that generates a filename (or filenames)

        //    return Created($"/api/v1/games/{game.Id}", _mapper.Map<GameDto>(game));



        //long size = files.Sum(f => f.Length);

        //foreach (var formFile in files)
        //{
        //    if (formFile.Length > 0)
        //    {
        //        var filePath = Path.GetTempFileName();

        //        using (var stream = System.IO.File.Create(filePath))
        //        {
        //            await formFile.CopyToAsync(stream);
        //        }
        //    }
        //}

        //// Process uploaded files
        //// Don't rely on or trust the FileName property without validation.

        //return Ok(new { count = files.Count, size });
        //}

        [HttpPut("{id}")]
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