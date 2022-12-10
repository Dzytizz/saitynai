using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using saitynai_server.Auth.Model;
using saitynai_server.Data.Dtos.Comments;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace saitynai_server.Controllers
{
    [Route("api/v1/games/{gameId}/advertisements/{advertisementId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IGamesRepository _gamesRepository;
        private readonly IAdvertisementsRepository _advertisementsRepository;
        private readonly ICommentsRepository _commentsRepository;

        public CommentsController(IMapper mapper, IAuthorizationService authorizationService, IGamesRepository gamesRepository, IAdvertisementsRepository advertisementsRepository, ICommentsRepository commentsRepository)
        {
            _mapper = mapper;
            _authorizationService = authorizationService;
            _gamesRepository = gamesRepository;
            _advertisementsRepository = advertisementsRepository;
            _commentsRepository = commentsRepository;
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AuthorizeByRoles(Roles.Admin, Roles.User)]
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

            //var authorizationResult = await _authorizationService.AuthorizeAsync(User, comment, PolicyNames.ResourceOwner);
            //if (!authorizationResult.Succeeded)
            //    return Forbid(); // could be 404 for security

            return Ok(_mapper.Map<CommentDto>(comment));
        }

        [HttpPost]
        [AuthorizeByRoles(Roles.User)]
        public async Task<ActionResult<CommentDto>> Create(int gameId, int advertisementId, CommentPostDto commentPostDto)
        {
            var game = await _gamesRepository.GetAsync(gameId);
            if (game == null)
                return NotFound($"Game with id '{gameId}' not found.");

            var advertisement = await _advertisementsRepository.GetAsync(gameId, advertisementId);
            if (advertisement == null)
                return NotFound($"Advertisement with fkGameId '{gameId}' and id '{advertisementId}' not found.");

            var comment = _mapper.Map<Comment>(commentPostDto);
            comment.EditDate = DateTime.UtcNow;
            comment.FkAdvertisement = advertisement;
            comment.UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            await _commentsRepository.CreateAsync(comment);

            return Created($"api/v1/games/{gameId}/advertisements/{advertisementId}/comments/{comment.Id}", _mapper.Map<CommentDto>(comment));
        }

        [HttpPut("{commentId}")]
        [AuthorizeByRoles(Roles.User)]
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

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, oldComment, PolicyNames.ResourceOwner);
            if (!authorizationResult.Succeeded)
                return Forbid(); // could be 404 for security

            _mapper.Map(commentUpdateDto, oldComment);
            oldComment.EditDate = DateTime.UtcNow;

            await _commentsRepository.UpdateAsync(oldComment);

            return Ok(_mapper.Map<CommentDto>(oldComment));
        }

        [HttpDelete("{commentId}")]
        [AuthorizeByRoles(Roles.Admin, Roles.User)]
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

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, comment, PolicyNames.ResourceOwner);
            if (!authorizationResult.Succeeded)
                return Forbid(); // could be 404 for security

            await _commentsRepository.DeleteAsync(comment);

            return NoContent();
        }
    }
}