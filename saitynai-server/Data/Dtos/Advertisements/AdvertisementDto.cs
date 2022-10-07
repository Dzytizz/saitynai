namespace saitynai_server.Data.Dtos.Advertisements
{
    public record AdvertisementDto
    (
        int Id,
        string Title,
        DateTime PublishDate,
        string Description,
        int Condition,
        decimal Price,
        string Photos,
        int? ExchangeTo,
        int FkGameId,
        int FkClientId
    );
}
