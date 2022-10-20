using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Entities
{
    public partial class Advertisement
    {
        [Required] public int Id { get; set; }
        [Required, StringLength(63)] public string Title { get; set; } = null!;
        [Timestamp] public DateTime EditDate { get; set; }
        [Required, StringLength(511)] public string Description { get; set; } = null!;
        [Required] public int? Condition { get; set; }
        [Required] public decimal? Price { get; set; }
        [Required, StringLength(511)] public string Photos { get; set; } = null!;
        public Game? ExchangeToGame { get; set; }
        [Required] public Game FkGame { get; set; } = null!;
        [Required] public Client FkClient { get; set; } = null!;
    }
}
