﻿using Application.Mapper.DTOs;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        public string Login(LoginDTO request);
        public string RefreshToken();
    }
}
