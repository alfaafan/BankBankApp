using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using BankBankApp.BO;
using BankBankApp.DAL.Interfaces;
using Dapper;

namespace BankBankApp.DAL
{
    public class RoleDAL : IRole
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
        }
        public void Create(Role obj)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Users.Roles (RoleName) VALUES (@RoleName)";
                var param = new
                {
                    RoleName = obj.RoleName
                };

                try
                {
                    int result = connection.Execute(sql, param);
                    if (result != 1)
                    {
                        throw new Exception("Error creating role");
                    }
                }
                catch (SqlException e)
                {
                    throw new ArgumentException($"{e.InnerException.Message} - {e.Number}");
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Error: " + e.Message);
                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "DELETE FROM Users.Roles WHERE RoleID = @RoleID";
                var param = new
                {
                    RoleID = id
                };

                try
                {
                    int result = connection.Execute(sql, param);
                    if (result != 1)
                    {
                        throw new Exception("Error deleting role");
                    }
                }
                catch (SqlException e)
                {
                    throw new ArgumentException($"{e.InnerException.Message} - {e.Number}");
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Error: " + e.Message);
                    throw;
                }
            }
        }

        public IEnumerable<Role> Get()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "SELECT * FROM Users.Roles ORDER BY RoleName";
                return connection.Query<Role>(sql);
            }
        }

        public Role GetByID(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "SELECT * FROM Users.Roles WHERE RoleID = @RoleID";
                var param = new
                {
                    RoleID = id
                };
                return connection.QueryFirstOrDefault<Role>(sql, param);
            }
        }

        public Role Update(Role obj, int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "UPDATE Users.Roles SET RoleName = @RoleName WHERE RoleID = @RoleID";
                var param = new
                {
                    RoleName = obj.RoleName,
                    RoleID = id
                };

                try
                {
                    int result = connection.Execute(sql, param);
                    if (result != 1)
                    {
                        throw new Exception("Error updating role");
                    }
                    return GetByID(id);
                }
                catch (SqlException e)
                {
                    throw new ArgumentException($"{e.InnerException.Message} - {e.Number}");
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Error: " + e.Message);
                    throw;
                }
            }
        }

        public void AddUserToRole(string username, int roleID)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                var sql = "INSERT INTO Users.UserRoles (RoleID, Username) VALUES (@Username, @RoleID)";
                var param = new
                {
                    Username = username,
                    RoleID = roleID
                };

                try
                {
                    int result = connection.Execute(sql, param);
                    if (result != 1)
                    {
                        throw new Exception("Error adding user to role");
                    }
                }
                catch (SqlException e)
                {
                    throw new ArgumentException($"{e.InnerException.Message} - {e.Number}");
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Error: " + e.Message);
                    throw;
                }
            }
        }
    }
}
