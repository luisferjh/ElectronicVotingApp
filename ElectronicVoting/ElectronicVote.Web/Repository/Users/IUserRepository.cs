using ElectronicVote.Entities;
using ElectronicVote.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Repository.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserViewModel>> List();
        Task<UserViewModel> GetUser(int id);
        Task AddUser(CreateViewModel model);
        Task<UserLoginViewModel> Login(LoginViewModel model);
        Task<UserStateViewModel> StateUser(int id);
        Task UpdateUser(UpdateViewModel model);              
        void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool CheckPassword(string password, byte[] passwordHashStored, byte[] passwordSaltStored);
        string GenerateToken(UserLoginViewModel user);
        Task<bool> UserExists(int id);
        Task<VoterUser> SearchUserById(int id);
    }
}
