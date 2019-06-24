using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ElectronicVote.Data;
using ElectronicVote.Entities;
using ElectronicVote.Web.Models.User;
using Microsoft.EntityFrameworkCore;

namespace ElectronicVote.Web.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextElectronicVote _context;
        public UserRepository(DbContextElectronicVote context)
        {
            _context = context;
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
            var user = await _context.VoterUsers.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel
            {
                IdUser = user.IdUser,
                IdRole = user.IdRole,
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

        public Task Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UpdateViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(VoterUser PUser)
        {
            throw new NotImplementedException();
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
       
    }
}
