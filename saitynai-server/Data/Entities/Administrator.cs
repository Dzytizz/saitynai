﻿using System;
using System.Collections.Generic;

namespace saitynai_server.Entities
{
    public partial class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int FkUserId { get; set; }
    }
}