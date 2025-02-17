﻿using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper.DTOs
{
    public class UserCredentialsDTO
    {
        public int ID { get; set; }
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public string? TokenCreated { get; set; }
        public string? TokenExpires { get; set; }
        public bool IsActive { get; set; } = true;
        public string UserRole { get; set; } = null!;
    }
}
