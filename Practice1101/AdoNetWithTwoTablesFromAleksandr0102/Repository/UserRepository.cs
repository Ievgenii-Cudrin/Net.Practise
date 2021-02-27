using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Repository
{
    public class UserRepository : IUserRepository
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;
        public void Create(User user)
        {
            string sqlExpression = String.Format("INSERT INTO Users (UserName, RolesId) VALUES (@name, @roleId)");

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

        public User Get(int id)
        {
            User user = new User();
            Role role = new Role();
            string sqlExpression = @"Select [Users].[Id], [Users].[UserName], [Users].[RolesId], [Roles].[RoleName] 
                                    from [Users]
                                    Left Join Roles On [Users].[RolesId] = [Roles].[Id]
                                    Where [Users].[Id] = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                while (reader.Read())
                {
                    try
                    {
                        role.Id = reader.GetInt32("RolesId");
                        role.Name = reader.GetString("RoleName");

                    }
                    catch
                    {
                        role = null;
                    }
                    finally
                    {
                        user.Id = reader.GetInt32("Id");
                        user.Name = reader.GetString("UserName");
                        user.UserRole = role;
                    }
                };

                user.UserRole = role;
                reader.Close();
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            string sqlExpression = @"select u.[Id], u.[UserName], r.[Id], r.[RoleName] 
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
                        User user = new User();
                        Role role = new Role();

                        try
                        {
                            role.Id = reader.GetInt32(2);
                            role.Name = reader.GetString(3);
                            
                        }
                        catch
                        {
                            role = null;
                        }
                        finally
                        {
                            user.Id = reader.GetInt32(0);
                            user.Name = reader.GetString(1);
                            user.UserRole = role;
                        }

                        users.Add(user);
                    }
                }

                reader.Close();
            }

            return users;
        }

        public void Update(User user)
        {
            string sqlExpression = $"UPDATE Users SET UserName=@name, RolesId=@roleId WHERE Id=@id";

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
