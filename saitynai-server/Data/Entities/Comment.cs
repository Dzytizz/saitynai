using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Entities
{
    public partial class Comment
    {
        [Required] public int Id { get; set; }
        [Timestamp] public DateTime EditDate { get; set; }
        [Required, StringLength(511)] public string Description { get; set; } = null!;
        //[Required] public Client FkClient { get; set; } = null!;
        [Required] public Advertisement FkAdvertisement { get; set; } = null!;
    }
}
