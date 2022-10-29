using saitynai_server.Data.Dtos.Games;

namespace saitynai_server.Data.Dtos.Advertisements
{
    public record AdvertisementDto
    (
        int Id,
        string Title,
        DateTime EditDate,
        string Description,
        int Condition,
        decimal Price,
        string Photos,
        GameDto? ExchangeToGame,
        GameDto FkGame
    );
}
