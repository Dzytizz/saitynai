using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Data.Dtos.Comments
{
    public record CommentPostDto
    (
        [Required, StringLength(511)] string Description
    );
}
