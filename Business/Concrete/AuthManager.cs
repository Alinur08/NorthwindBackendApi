using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var token= _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>("Token created",token);
        }

        public IDataResult<User> Login(UserForLoginDto user)
        {
            var userToCheck = _userService.GetUserByMail(user.Email);
            if (userToCheck==null)
            {
                return new ErrorDataResult<User>("User not found");
            }
            if (!HashingHelper.Verify(user.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Password is invalid");
            }
            return new SuccessDataResult<User>("User logined",userToCheck);
        }

        public IDataResult<User> Register(UserForRegister userForRegister)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegister.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>("User registered",user);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetUserByMail(email) != null)
            {
                return new ErrorResult("User is exist");
            }
            return new SuccessResult();
        }
    }
}
