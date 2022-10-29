using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace saitynai_server.Data.Dtos.Advertisements
{
    public record AdvertisementPostDto
    (
        [Required, StringLength(63)] string Title,
        [Required, StringLength(511)] string Description,
        [Required, Range(1, 10)] int Condition,
        [Required, Range(0.00, 9999.99)] decimal Price,
        [StringLength(511)] string Photos,
        int? ExchangeToGameId
    );
}
