using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;
using BankBankApp.BLL.Interfaces;
using BankBankApp.BO;

namespace BankBankApp.BLL
{
    public class RoleBLL : IRole
    {
        private readonly DAL.Interfaces.IRole _roleDAL;
        public RoleBLL()
        {
            _roleDAL = new DAL.RoleDAL();
        }
        public void AddRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public void AddUserToRole(string username, int roleID)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be empty");
            }
            if (roleID <= 0)
            {
                throw new ArgumentException("Role ID cannot be empty");
            }
            try
            {
                _roleDAL.AddUserToRole(username, roleID);
            }
            catch (Exception e)
            {
                throw new Exception("Error adding user to role", e);
            }
        }

        public void DeleteRole(int roleID)
        {
            if (roleID <= 0)
            {
                throw new ArgumentException("Role ID cannot be empty");
            }
            try
            {
                _roleDAL.Delete(roleID);
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting role", e);
            }
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            try
            {
                var result = _roleDAL.Get();
                foreach (var role in result)
                {
                    roles.Add(new RoleDTO
                    {
                        RoleName = role.RoleName
                    });
                }
                return roles;
            }
            catch (Exception e)
            {
                throw new Exception("Error getting roles", e);
            }
        }

        public RoleDTO GetRoleByID(int roleID)
        {
            if (roleID <= 0)
            {
                throw new ArgumentException("Role ID cannot be empty");
            }
            try
            {
                var role = _roleDAL.GetByID(roleID);
                return new RoleDTO
                {
                    RoleName = role.RoleName
                };
            }
            catch (Exception e)
            {
                throw new Exception("Error getting role", e);
            }
        }

        public RoleDTO GetRoleByName(string roleName)
        {
            throw new NotImplementedException();
        }

        public void UpdateRole(RoleDTO role, int roleID)
        {
            if (string.IsNullOrEmpty(role.RoleName))
            {
                throw new ArgumentException("Role name cannot be empty");
            }
            if (roleID <= 0)
            {
                throw new ArgumentException("Role ID cannot be empty");
            }
            try
            {
                _roleDAL.Update(new Role
                {
                    RoleName = role.RoleName
                }, roleID);
            }
            catch (Exception e)
            {
                throw new Exception("Error updating role", e);
            }
        }
    }
}
