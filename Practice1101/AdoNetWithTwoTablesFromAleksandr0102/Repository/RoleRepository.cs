using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Repository
{
    public class RoleRepository : IRoleRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
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
                Console.WriteLine("Добавлен объект");
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = $"DELETE FROM Roles WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
                Console.WriteLine("Удален объект");
            }
        }

        public Role Get(int id)
        {
            Role role = new Role();
            string sqlExpression = "SELECT * FROM Roles WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                role.Id = reader.GetInt32(0);
                role.Name = reader.GetString(1);

                reader.Close();
            }

            return role;
        }

        public IEnumerable<Role> GetAll()
        {
            List<Role> roles = new List<Role>();
            string sqlExpression = "SELECT * FROM Roles";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
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

        public List<User> GetAllUserInRole(int roleId)
        {
            List<User> users = new List<User>();
            string sqlExpression = @"select u.[Id], u.[UserName], u.[RolesId], r.[RoleName]
                                    from [Users] u
                                    Left Join Roles r On u.[RolesId] = r.[Id]
                                    Where r.[Id] = 2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Role role = new Role()
                        {
                            Id = reader.GetInt32(2),
                            Name = reader.GetString(3)
                        };
                        User user = new User()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            UserRole = role
                        };

                        users.Add(user);
                    }
                }

                reader.Close();
            }

            return users;
        }
    }
}
