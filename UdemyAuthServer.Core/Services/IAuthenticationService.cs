﻿using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthServer.Core.DTOs;

namespace UdemyAuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken);
        Task<CustomResponseDto<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto);

    }
}
