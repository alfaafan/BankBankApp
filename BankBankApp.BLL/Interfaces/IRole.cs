using System;
using System.Collections.Generic;
using System.Text;
using BankBankApp.BLL.DTOs;

namespace BankBankApp.BLL.Interfaces
{
    public interface IRole
    {
        void AddUserToRole(string username, int roleID);
        void AddRole(string roleName);
        void DeleteRole(int roleID);
        void UpdateRole(RoleDTO role, int roleID);
        RoleDTO GetRoleByID(int roleID);
        RoleDTO GetRoleByName(string roleName);
        IEnumerable<RoleDTO> GetAllRoles();

    }
}
