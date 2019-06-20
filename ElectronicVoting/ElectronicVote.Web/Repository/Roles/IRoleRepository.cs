using ElectronicVote.Entities;
using ElectronicVote.Web.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Repository.Roles
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleViewModel>> List();
        Task<RoleViewModel> GetRole(int id);
        Task AddRole(CreateViewModel model);
        Task UpdateRole(UpdateViewModel model);
        Task<Role> SearchRoleById(int id);
        Task<bool> RoleExists(int id);
    }
}
