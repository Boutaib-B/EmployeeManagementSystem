﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.dto
{
    public class loginrequestdto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
