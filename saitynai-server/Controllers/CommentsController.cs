using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using saitynai_server.Data.Dtos.Advertisements;
using saitynai_server.Data.Dtos.Comments;

namespace saitynai_server.Controllers
{
    [Route("api/v1/games/{gameId}/advertisements/{advertisementId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGamesRepository _gamesRepository;
        private readonly IAdvertisementsRepository _advertisementsRepository;
        private readonly ICommentsRepository _commentsRepository;

        public CommentsController(IMapper mapper, IGamesRepository gamesRepository, IAdvertisementsRepository advertisementsRepository, ICommentsRepository commentsRepository)
        {
            _mapper = mapper;
            _gamesRepository = gamesRepository;
            _advertisementsRepository = advertisementsRepository;
            _commentsRepository = commentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAll(int gameId, int advertisementId)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if (advertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' and  not found.");

            var comments = await _commentsRepository.GetAllAsync(advertisementId);

            return Ok(comments.Select(o => _mapper.Map<CommentDto>(o)));
        }

        [HttpGet("{commentId}")]
        public async Task<ActionResult<CommentDto>> Get(int gameId, int advertisementId, int commentId)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if (advertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' not found.");

            var comment = await _commentsRepository.GetAsync(advertisementId, commentId);
            if (comment == null)
                return NotFound($"Comment with fkAdvertisementId '{advertisementId}' and id '{commentId}' not found.");

            return Ok(_mapper.Map<CommentDto>(comment));
        }

        [HttpPost]
        public async Task<ActionResult<CommentDto>> Create(int gameId, int advertisementId, CommentPostDto commentPostDto)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if (advertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' not found.");

            var comment = _mapper.Map<Comment>(commentPostDto);
            comment.PublishDate = DateTime.UtcNow;
            comment.FkAdvertisementId = advertisementId;
            comment.FkClientId = 1;  // ====================TEMPORARY=================

            await _commentsRepository.CreateAsync(comment);

            return Created($"api/v1/games/{gameId}/advertisements/{advertisementId}/comments/{comment.Id}", _mapper.Map<CommentDto>(comment));
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult<CommentDto>> Update(int gameId, int advertisementId, int commentId, CommentUpdateDto commentUpdateDto)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if (advertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' not found.");

            var oldComment = await _commentsRepository.GetAsync(advertisementId, commentId);
            if (oldComment == null)
                return NotFound($"Comment with fkAdvertisementId '{advertisementId}' and id '{commentId}' not found.");

            _mapper.Map(commentUpdateDto, oldComment);

            await _commentsRepository.UpdateAsync(oldComment);

            return Ok(_mapper.Map<CommentDto>(oldComment));
        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult> Remove(int gameId, int advertisementId, int commentId)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if (advertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' not found.");

            var comment = await _commentsRepository.GetAsync(advertisementId, commentId);
            if (comment == null)
                return NotFound($"Comment with fkAdvertisementId '{advertisementId}' and id '{commentId}' not found.");

            await _commentsRepository.DeleteAsync(comment);

            return NoContent();
        }
    }
}