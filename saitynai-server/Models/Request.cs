using System;
using System.Collections.Generic;

namespace saitynai_server.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public string GameTitle { get; set; } = null!;
        public string AdditionalInfo { get; set; } = null!;
        public int FkClientId { get; set; }
    }
}
