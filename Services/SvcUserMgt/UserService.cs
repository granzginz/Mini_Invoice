﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MiniInvoiceAPI.Helper;
using MiniInvoiceAPI.Interface.IUserMgt;
using MiniInvoiceAPI.Model.Authentication;
using MiniInvoiceAPI.Model.UserMgt;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MiniInvoiceAPI.Services.SvcUserMgt
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" },
            new User { Id = 2, FirstName = "Test2", LastName = "User2", Username = "test2", Password = "test2" },
            new User { Id = 3, FirstName = "Test3", LastName = "User3", Username = "test3", Password = "test3" },
            new User { Id = 4, FirstName = "Test4", LastName = "User4", Username = "test4", Password = "test4" }
        };

        private readonly AppSettings _appSettings;


        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            if (token == null)
            {
                var kuki = new Cookie("Token", token);
                
            }

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 1 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //set session di browser kuki
           // var kukiCookie = new Cookie("Token", tokenHandler.(token));


            return tokenHandler.WriteToken(token);
        }
    }
}
