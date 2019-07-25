using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ElectronicVote.Data;
using ElectronicVote.Entities;
using ElectronicVote.Web.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ElectronicVote.Web.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextElectronicVote _context;
        private readonly IConfiguration _config;

        public UserRepository(DbContextElectronicVote context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<IEnumerable<UserViewModel>> List()
        {
            var users = await _context.VoterUsers
                .Include(r => r.Role)
                .ToListAsync();

            return users.Select(u => new UserViewModel
            {
                IdUser = u.IdUser,
                IdRole = u.IdRole,
                FullName = u.FullName,
                Email = u.Email,
                Age = u.Age,
                Record = u.Record,
                Voted = u.Voted
            });
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            var user = await _context.VoterUsers
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.IdUser == id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel
            {
                IdUser = user.IdUser,
                IdRole = user.IdRole,
                Role = user.Role.RoleName,
                FullName = user.FullName,
                Email = user.Email,
                Age = user.Age,
                Record = user.Record,
                Voted = user.Voted
            };
        }

        public async Task AddUser(CreateViewModel model)
        {
            CreatePassword(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            VoterUser user = new VoterUser
            {
                IdRole = model.IdRole,
                FullName = model.FullName,
                Age = model.Age,
                Record = model.Record,
                Email = model.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Voted = false
            };

            await _context.VoterUsers.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task<UserLoginViewModel> Login(LoginViewModel model)
        {
            var user = await _context.VoterUsers
                .Include(u=> u.Role)
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            return new UserLoginViewModel
            {
                IdUser = user.IdUser,
                IdRole = user.IdRole,
                Role = user.Role.RoleName,
                FullName = user.FullName,
                Age = user.Age,
                Record = user.Record,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                Voted = user.Voted
            };
        }

        public string GenerateToken(UserLoginViewModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("IdVoterUser", user.IdUser.ToString()),
                new Claim("Role", user.Role),
                new Claim("Name", user.FullName)
            };

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims:claims,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<VoterUser> SearchUserById(int id)
        {
            var user = await _context.VoterUsers.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.VoterUsers.AnyAsync(u => u.IdUser == id);
        }

        public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool CheckPassword(string password, byte[] passwordHashStored, byte[] passwordSaltStored)
        {
            using (var hmac = new HMACSHA512(passwordSaltStored))
            {
                var newPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashStored).SequenceEqual(new ReadOnlySpan<byte>(newPasswordHash));
            }
        }

        public async Task UpdateUser(UpdateViewModel model)
        {
            var user = await _context.VoterUsers                
                .FindAsync(model.IdUser);

            user.IdUser = model.IdUser;
            user.IdRole = model.IdRole;
            user.FullName = model.FullName;
            user.Age = model.Age;
            user.Email = model.Email;
            user.Record = model.Record;         
            user.Voted = model.Voted;            

            await _context.SaveChangesAsync();
        }        
    }
}
