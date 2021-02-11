using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandr0102.Repository
{
    public class UserRepository : IUserRepository
    {
        static string connectionString;
        List<User> usersCache;

        public UserRepository(string connectionStr)
        {
            connectionString = connectionStr;
            this.usersCache = GetAllUsers();
        }

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

                //Add to cache
                if (!this.usersCache.Contains(user))
                {
                    this.usersCache.Add(user);
                }

                Console.WriteLine("Добавлен объект");
            }
        }

        public void Delete(User user)
        {
            string sqlExpression = $"DELETE FROM Roles WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@id", user.Id);
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();

                if (this.usersCache.Find(x => x.Id == user.Id) != null)
                {
                    //Delete from cache
                    this.usersCache.Remove(user);
                }

                Console.WriteLine("Удален объект");
            }
        }

        public User Get(int id)
        {
            User userFromCache = this.usersCache.Find(x => x.Id == id);

            if (userFromCache != null)
            {
                //Get from cache
                return userFromCache;
            }

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

        public IEnumerable<User> GetAllForOnePage(int skip)
        {
            string sqlExpression = @"select u.[Id], u.[UserName], r.[Id], r.[RoleName] 
                                    from [Users] u
                                    Left Join Roles r On u.[RolesId] = r.[Id]
									order by u.[id]
									offset @skip rows fetch next 10 rows only";

            return GetUsersWithExpression(skip, sqlExpression).ToList();
        }

        List<User> GetAllUsers()
        {
            string sqlExpression = @"select u.[Id], u.[UserName], r.[Id], r.[RoleName] 
                                    from [Users] u
                                    Left Join Roles r On u.[RolesId] = r.[Id]";

            return GetUsersWithExpression(null, sqlExpression).ToList();
        }

        IEnumerable<User> GetUsersWithExpression(int? skip, string sqlExpression)
        {
            List<User> users = new List<User>();
            

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
                        User user = new User();
                        Role role = new Role();

                        try
                        {
                            role.Id = reader.GetInt32(2);
                            role.Name = reader.GetString(3);
                            
                        }
                        catch(SqlNullValueException ex)
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
            User userToUpdate = this.usersCache.Find(x => x.Id == user.Id);

            if (userToUpdate != null)
            {
                //Update role in cache
                userToUpdate.Name = user.Name;
                userToUpdate.RoleId = user.RoleId;
            }

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

        public void UpdateRoleInUsersCache(Role role)
        {
            var usersWithRoleForUpdate = this.usersCache.Where(x => x.RoleId == role.Id);
            foreach(var user in usersWithRoleForUpdate)
            {
                user.UserRole.Name = role.Name;
            }
        }
    }
}
