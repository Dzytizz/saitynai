using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Entities
{
    public partial class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string Rules { get; set; } = null!;
        public int Difficulty { get; set; }
        public string Photos { get; set; } = null!;
    }
}
