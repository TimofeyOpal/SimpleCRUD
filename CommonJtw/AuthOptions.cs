using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CommonJtw
{
    public class AuthOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secter { get; set; }
        public int TokenLifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes("какойтоключвыражения"));
        }

    }
}
