﻿using System;
using System.Collections.Generic;

namespace saitynai_server.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}