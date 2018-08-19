using Backend.BusinessLogic.DTO.Request;
using Backend.BusinessLogic.DTO.Response;
using System;
using System.Collections.Generic;

namespace Backend.BusinessLogic
{
    public interface IUserService
    {
        List<UserResponseDTO> GetAll();

        UserResponseDTO GetByEmail(string email);

        void Create(CreateUserRequestDTO dto);

        void UpdateRefreshToken(Guid idUser, string token);

        void RevokeRefreshToken(Guid idUser);

        bool IsValidUser(string email, string refreshToken);
    }
}
