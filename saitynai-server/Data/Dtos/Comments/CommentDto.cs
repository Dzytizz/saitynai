namespace saitynai_server.Data.Dtos.Comments
{
    public record CommentDto
    (
        int Id,
        DateTime PublishDate,
        string Description,
        int FkClientId,
        int FkAdvertisementId
    );
}
