using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Data;
using ElectronicVote.Entities;
using ElectronicVote.Web.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace ElectronicVote.Web.Repository.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContextElectronicVote _context;
        public RoleRepository(DbContextElectronicVote context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleViewModel>> List()
        {
            var roles = await _context.Roles.ToListAsync();

            return roles.Select(r => new RoleViewModel
            {
                IdRole = r.IdRole,
                RoleName = r.RoleName,
                Condition = r.Condition
            });
        }
        public async Task<RoleViewModel> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return null;
            }
            
            return new RoleViewModel {
                IdRole = role.IdRole,
                RoleName = role.RoleName,
                Condition = role.Condition
            };
        }

        public async Task AddRole(CreateViewModel model)
        {
            var role = new Role
            {
                RoleName = model.RoleName,
                Condition = model.Condition
            };

            await _context.Roles.AddAsync(role);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRole(UpdateViewModel model)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.IdRole == model.IdRole);          

            role.IdRole = model.IdRole;
            role.RoleName = model.RoleName;
            role.Condition = model.Condition;

            await _context.SaveChangesAsync();
        }

        public Task<Role> SearchRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RoleExists(int id)
        {
            return await _context.Roles.AnyAsync(r => r.IdRole == id);
        }
    }
}
