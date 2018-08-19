using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Api.Models
{
    public class TokenModel
    {
        public TokenModel(string accessToken, string refreshToken)
        {
            this.Token = accessToken;
            this.RefreshToken = refreshToken;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}