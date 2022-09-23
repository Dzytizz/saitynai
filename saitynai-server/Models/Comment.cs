using System;
using System.Collections.Generic;

namespace saitynai_server.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; } = null!;
        public int FkClientId { get; set; }
        public int FkAdvertisementId { get; set; }
    }
}
