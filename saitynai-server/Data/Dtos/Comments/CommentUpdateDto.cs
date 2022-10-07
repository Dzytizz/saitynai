using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Data.Dtos.Comments
{
    public record CommentUpdateDto
    (
         [Required, StringLength(511)] string Description
    );
}
