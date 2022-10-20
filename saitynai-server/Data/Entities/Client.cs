using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Entities
{
    public partial class Client
    {
        [Required] public int Id { get; set; }
        [Required, StringLength(63)] public string Name { get; set; } = null!;
        [Required, StringLength(63)] public string Surname { get; set; } = null!;
        [Required, StringLength(15), Phone] public string Phone { get; set; } = null!;
        [Required] public User FkUser { get; set; } = null!;
    }
}
