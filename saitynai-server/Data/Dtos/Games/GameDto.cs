using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Data.Dtos.Games
{
    public record GameDto(
        int Id,
        string Title,
        string Description,
        int MinPlayers,
        int MaxPlayers,
        string Rules,
        int Difficulty,
        string Photos
    );
}
