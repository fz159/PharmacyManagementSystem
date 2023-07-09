using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PharmacyManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.BAL.Authentication
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _secretKey;



        public JwtTokenManager(IConfiguration config)
        {
            _config = config;



            // Generate a random secret key
            _secretKey = new SymmetricSecurityKey(new byte[32]); // 256 bits
            using (var generator = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                generator.GetBytes(_secretKey.Key);
            }



            // Debug statements
            Console.WriteLine($"Secret key size: {_secretKey.KeySize}");
            Console.WriteLine($"Base64-encoded secret key: {Convert.ToBase64String(_secretKey.Key)}");
        }



        public string GenerateToken(Admin admin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   // new Claim("id", admin.Id.ToString()),
                    new Claim("Admin_name", admin.Admin_name),
                    new Claim("Admin_mailid", admin.Admin_mailid),
                    new Claim("Admin_id", _config["Jwt:Admin_id"])

                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:TokenLifetimeInMinutes"])),
                SigningCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256Signature)
            };
            Console.WriteLine($"Subject: {tokenDescriptor.Subject}");
            Console.WriteLine($"Expires: {tokenDescriptor.Expires}");
            Console.WriteLine($"SigningCredentials: {tokenDescriptor.SigningCredentials}");



            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   // new Claim("id", user.Id.ToString()),
                    new Claim("User_mailid", user.User_mailid),
                    new Claim("User_name", user.User_name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:TokenLifetimeInMinutes"])),
                SigningCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256Signature)
            };
            Console.WriteLine($"Subject: {tokenDescriptor.Subject}");
            Console.WriteLine($"Expires: {tokenDescriptor.Expires}");
            Console.WriteLine($"SigningCredentials: {tokenDescriptor.SigningCredentials}");



            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
