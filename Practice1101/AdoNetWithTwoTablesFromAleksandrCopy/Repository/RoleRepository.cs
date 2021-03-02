using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdoNetWithTwoTablesFromAleksandr0102.Repository
{
    public class RoleRepository : IRoleRepository
    {
        List<Role> rolesCache;
        static string connectionString;

        public RoleRepository(string connectionStr)
        {
            connectionString = connectionStr;
            this.rolesCache = GetAllRoles();
        }

        
        public void Create(Role role)
        {
            string sqlExpression = String.Format("INSERT INTO Roles (RoleName) VALUES (@name)");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", role.Name);
                command.Parameters.Add(nameParam);
                command.ExecuteNonQuery();
                
                //Add to cache
                if (!this.rolesCache.Contains(role))
                {
                    this.rolesCache.Add(role);
                }

                Console.WriteLine("Добавлен объект");
            }
        }

        public void Delete(Role role)
        {
            string sqlExpression = @"DELETE FROM Roles WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", role.Id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();

                if(this.rolesCache.Find(x => x.Id == role.Id) != null)
                {
                    //Delete from cache
                    this.rolesCache.Remove(role);
                }

                Console.WriteLine("Удален объект");
            }
        }

        public Role Get(int id)
        {
            Role role = this.rolesCache.Find(x => x.Id == id);

            if(role != null)
            {
                //Get from cache
                return role;
            }

            string sqlExpression = "SELECT * FROM Roles WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                role = new Role();
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                while (reader.Read())
                {
                    role.Id = reader.GetInt32("Id");
                    role.Name = reader.GetString("RoleName");
                };

                reader.Close();
            }

            return role;
        }

        public List<Role> GetAllForOnePage(int skip)
        {
            string sqlExpression = @"SELECT *
                                        FROM Roles
                                        Order by ID
                                        OFFSET @skip ROWS FETCH NEXT 10 ROWS ONLY";

            return GetRolesForOnePage(skip, sqlExpression).ToList();
        }

        List<Role> GetAllRoles()
        {
            string sqlExpression = @"SELECT *
                                        FROM Roles";

            return GetRolesForOnePage(null, sqlExpression).ToList();
        }

        IEnumerable<Role> GetRolesForOnePage(int? skip, string sqlExpression)
        {
            List<Role> roles = new List<Role>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                if(skip != null)
                {
                    SqlParameter skipParam = new SqlParameter("@skip", skip);
                    command.Parameters.Add(skipParam);
                }

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role role = new Role()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };

                        roles.Add(role);
                    }
                }

                reader.Close();
            }

            return roles;
        }

        public void Update(Role role)
        {
            Role roleToUpdate = this.rolesCache.Find(x => x.Id == role.Id);

            if(roleToUpdate != null)
            {
                //Update role in cache
                roleToUpdate.Name = role.Name;
            }

            string sqlExpression = $"UPDATE Roles SET RoleName=@name WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", role.Name);
                command.Parameters.Add(nameParam);
                SqlParameter idParam = new SqlParameter("@id", role.Id);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
                Console.WriteLine("Обновлен объект");
            }
        }
    }
}
