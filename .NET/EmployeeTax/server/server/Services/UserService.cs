using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server.Services
{
    public class UserService
    {
        private readonly EmployeeTaxDbContext _db;
        private readonly IConfiguration _configuration;

        public UserService(EmployeeTaxDbContext db, IConfiguration configuration)
        {
            _db=db;
            _configuration=configuration;
        }


        public async Task<IActionResult> login(User user)
        {
            var result = await _db.Login(user.empId, user.password);  
            if (result.Success)
            {
                var token = GenerateJwtToken(result.Data);
                return new OkObjectResult(new { token, employee = result.Data });
            }

            return new UnauthorizedResult();
        }

        private string GenerateJwtToken(Employee employee)
        {
            // Load JWT settings from configuration
            var jwtSettings = _configuration.GetSection("Jwt");
            var jwtIssuer = jwtSettings["Issuer"];
            var jwtAudience = jwtSettings["Audience"];
            var jwtExpireHours = Convert.ToDouble(jwtSettings["ExpireHours"]);

            // Generate claims
            var authClaims = new[]
            {
                new Claim(ClaimTypes.Name, employee.name),
                new Claim(ClaimTypes.Role, employee.role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            // Load secret key from configuration
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HSAPGALXsadjksaWTIZXsaxasxIODVIPQ"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Set token expiration
            var expires = DateTime.UtcNow.AddHours(jwtExpireHours);

            // Create JWT token
            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                expires: expires,
                claims: authClaims,
                signingCredentials: creds
            );

            // Write token
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

    }
}
