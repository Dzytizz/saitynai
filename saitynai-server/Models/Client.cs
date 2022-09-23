using System;
using System.Collections.Generic;

namespace saitynai_server.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int FkUserId { get; set; }
    }
}
