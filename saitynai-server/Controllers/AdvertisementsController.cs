using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saitynai_server.Data.Dtos.Advertisements;

namespace saitynai_server.Controllers
{
    [Route("api/v1/games/{gameId}/advertisements")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementsRepository _advertisementsRepository;
        private readonly IGamesRepository _gamesRepository;

        public AdvertisementsController(IMapper mapper, IAdvertisementsRepository advertisementsRepository, IGamesRepository gamesRepository)
        {
            _mapper = mapper;
            _advertisementsRepository = advertisementsRepository;
            _gamesRepository = gamesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvertisementDto>>> GetAll(int gameId)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisements = await _advertisementsRepository.GetAllAsync(gameId);

            return Ok(advertisements.Select(o => _mapper.Map<AdvertisementDto>(o)));
        }

        [HttpGet("{advertisementId}")]
        public async Task<ActionResult<AdvertisementDto>> Get(int gameId, int advertisementId)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if (advertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' not found.");

            return Ok(_mapper.Map<AdvertisementDto>(advertisement));
        }

        [HttpPost]
        public async Task<ActionResult<AdvertisementDto>> Create(int gameId, AdvertisementPostDto advertisementPostDto)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var exchangeToGame = advertisementPostDto.ExchangeToGameId == null ? null : await _gamesRepository.GetAsync(advertisementPostDto.ExchangeToGameId.Value);
            if (advertisementPostDto.ExchangeToGameId != null && exchangeToGame == null)
                return NotFound($"Exchange game with id '{advertisementPostDto.ExchangeToGameId}' not found.");

            var advertisement = _mapper.Map<Advertisement>(advertisementPostDto);
            if(advertisement.Photos == null)
                advertisement.Photos = "default.jpg";
            advertisement.ExchangeToGame = exchangeToGame;
            advertisement.FkGame = game;
            // ==============| SET USER ID HERE |===============
          
            await _advertisementsRepository.CreateAsync(advertisement);

            return Created($"api/v1/games/{gameId}/advertisements/{advertisement.Id}", _mapper.Map<AdvertisementDto>(advertisement));
        }

        [HttpPut("{advertisementId}")]
        public async Task<ActionResult<AdvertisementDto>> Update(int gameId, int advertisementId, AdvertisementUpdateDto advertisementUpdateDto)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var oldAdvertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if (oldAdvertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' not found.");

            var exchangeToGame = advertisementUpdateDto.ExchangeToGameId == null ? null : await _gamesRepository.GetAsync(advertisementUpdateDto.ExchangeToGameId.Value);
            if (advertisementUpdateDto.ExchangeToGameId != null && exchangeToGame == null)
                return NotFound($"Exchange game with id '{advertisementUpdateDto.ExchangeToGameId}' not found.");

            _mapper.Map(advertisementUpdateDto, oldAdvertisement);
            if (!oldAdvertisement.Photos.Equals(advertisementUpdateDto.Photos))
                FilesController.Delete(oldAdvertisement.Photos);
            oldAdvertisement.ExchangeToGame = exchangeToGame;

            await _advertisementsRepository.UpdateAsync(oldAdvertisement);

            return Ok(_mapper.Map<AdvertisementDto>(oldAdvertisement));
        }

        [HttpDelete("{advertisementId}")]
        public async Task<ActionResult> Remove(int gameId, int advertisementId)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if(advertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' not found.");

            await _advertisementsRepository.DeleteAsync(advertisement);

            return NoContent();
        }
    }
}