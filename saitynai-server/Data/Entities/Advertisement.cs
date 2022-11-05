using saitynai_server.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Entities
{
    public partial class Advertisement : IUserOwnedResource
    {
        [Required] public int Id { get; set; }
        [Required, StringLength(63)] public string Title { get; set; } = null!;
        [Timestamp] public DateTime EditDate { get; set; }
        [Required, StringLength(511)] public string Description { get; set; } = null!;
        [Required] public int? Condition { get; set; }
        [Required, Precision(18,2)] public decimal? Price { get; set; }
        [Required, StringLength(511)] public string Photos { get; set; } = null!;
        public Game? ExchangeToGame { get; set; }
        [Required] public Game FkGame { get; set; } = null!;
        [Required] public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
