using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Entities
{
    public partial class Game
    {
        [Required] public int Id { get; set; }
        [Required, StringLength(127)] public string Title { get; set; } = null!;
        [Required, StringLength(511)] public string Description { get; set; } = null!;
        [Required] public int? MinPlayers { get; set; }
        [Required] public int? MaxPlayers { get; set; }
        [Required, StringLength(511)] public string Rules { get; set; } = null!;
        [Required, Range(1,5)] public int? Difficulty { get; set; }
        [Required, StringLength(511)] public string Photos { get; set; } = null!;
    }
}
