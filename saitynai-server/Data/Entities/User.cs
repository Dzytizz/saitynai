using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace saitynai_server.Entities
{
    [Index(nameof(Nickname), IsUnique = true), Index(nameof(Email), IsUnique = true)]
    public partial class User
    {
        [Required] public int Id { get; set; }
        [Required, StringLength(31)] public string Nickname { get; set; } = null!;
        [Required, StringLength(31)] public string Password { get; set; } = null!;
        [Required, StringLength(31), EmailAddress] public string Email { get; set; } = null!;
    }
}
