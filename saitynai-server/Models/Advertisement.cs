using System;
using System.Collections.Generic;

namespace saitynai_server.Models
{
    public partial class Advertisement
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; } = null!;
        public int Condition { get; set; }
        public decimal Price { get; set; }
        public string Photos { get; set; } = null!;
        public int? EnchangeTo { get; set; }
        public int FkGameId { get; set; }
        public int FkClientId { get; set; }
    }
}
