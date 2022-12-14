using saitynai_server.Controllers;
using System.ComponentModel.DataAnnotations;
using static saitynai_server.Helpers.CustomValidationAttributes;

namespace saitynai_server.Data.Dtos.Games
{
    public record GameUpdateDto(
        [Required, StringLength(127)] string Title,
        [Required, StringLength(511)] string Description,
        [Required, Range(1, 128)] int MinPlayers,
        [Required, HigherOrEqualInt("MinPlayers")] int MaxPlayers,
        [Required, StringLength(511)] string Rules,
        [Required, Range(1, 5)] int Difficulty,
        [StringLength(511)] string? Photos
    );
}
