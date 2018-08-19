using Backend.BusinessLogic.DTO.Request;
using Backend.BusinessLogic.DTO.Response;
using Backend.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Backend.BusinessLogic
{
    public class UserService : BaseService,  IUserService
    {        
        public UserService()
            : base()
        {               
        }

        public void Create(CreateUserRequestDTO dto)
        {
            User newUser = AutoMapper.Mapper.Map<User>(dto);

            newUser.IdRoles.ToList().ForEach(x =>
            {
                newUser.Roles.Add(this.UnitOfWork.RoleRepository.FindById(x));
            });

            this.UnitOfWork.UserRepository.Add(newUser);

            this.UnitOfWork.SaveChanges();
        }

        public List<UserResponseDTO> GetAll()
        {
            return AutoMapper.Mapper.Map<List<UserResponseDTO>>(this.UnitOfWork.UserRepository.GetAll());
        }

        public UserResponseDTO GetByEmail(string email)
        {
           return AutoMapper.Mapper.Map<UserResponseDTO>(this.UnitOfWork.UserRepository.FindByEmail(email));
        }

        public bool IsValidUser(string email, string refreshToken)
        {
            var user = this.UnitOfWork.UserRepository.FindByEmail(email);

            return user != null && user.RefreshToken == refreshToken;
        }

        public void RevokeRefreshToken(Guid idUser)
        {
            var user = this.UnitOfWork.UserRepository.FindById(idUser);
            user.RefreshToken = null;
            this.UnitOfWork.UserRepository.Update(user);
            this.UnitOfWork.SaveChanges();
        }

        public void UpdateRefreshToken(Guid idUser, string token)
        {
            var user = this.UnitOfWork.UserRepository.FindById(idUser);
            user.RefreshToken = token;
            this.UnitOfWork.UserRepository.Update(user);
            this.UnitOfWork.SaveChanges();
        }
    }

}
