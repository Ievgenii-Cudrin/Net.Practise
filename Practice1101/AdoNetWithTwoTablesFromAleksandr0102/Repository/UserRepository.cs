using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Repository
{
    public class UserRepository : IUserRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
        public void Create(User user)
        {
            string sqlExpression = String.Format("INSERT INTO Users (Name, RoleId) VALUES (@name, @roleId)");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", user.Name);
                command.Parameters.Add(nameParam);
                SqlParameter roleParam = new SqlParameter("@roleId", user.UserRole.Id);
                command.Parameters.Add(roleParam);

                command.ExecuteNonQuery();
                Console.WriteLine("Добавлен объект");
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = $"DELETE FROM Users WHERE Id=@id";

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

        public User Get(int id)
        {
            User user = new User();
            string sqlExpression = @"select u.[Id], u.[Name], r.[Id], r.[Name] 
                                    from [Users] u
                                    Left Join Roles r On u.[RolesId] = r.[Id]
                                    Where u.[Id] = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader();

                user.Id = reader.GetInt32(0);
                user.Name = reader.GetString(1);
                user.UserRole.Id = reader.GetInt32(2);
                user.UserRole.Name = reader.GetString(3);
                reader.Close();
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            string sqlExpression = @"select u.[Id], u.[Name], r.[Id], r.[Name] 
                                    from [Users] u
                                    Left Join Roles r On u.[RolesId] = r.[Id]";
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

        public void Update(User user)
        {
            string sqlExpression = $"UPDATE Users SET Name=@name, RoleId=@roleId WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", user.Name);
                command.Parameters.Add(nameParam);
                SqlParameter roleParam = new SqlParameter("@roleId", user.UserRole.Id);
                command.Parameters.Add(roleParam);
                SqlParameter idParam = new SqlParameter("@id", user.Id);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
                Console.WriteLine("Обновлен объект");
            }
        }
    }
}
