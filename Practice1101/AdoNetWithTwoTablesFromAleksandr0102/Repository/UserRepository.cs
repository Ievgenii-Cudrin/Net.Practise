﻿using AdoNetWithTwoTablesFromAleksandr0102.Entities;
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
            string sqlExpression = String.Format("INSERT INTO Users (Name, RoleId) VALUES (@name, @role)");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", user.Name);
                command.Parameters.Add(nameParam);
                SqlParameter roleParam = new SqlParameter("@role", user.RoleId);
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
            string sqlExpression = "SELECT * FROM Users WHERE Id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                user.Id = reader.GetInt32(0);
                user.Name = reader.GetString(1);
                user.RoleId = reader.GetInt32(2);

                reader.Close();
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            RoleId = reader.GetInt32(2)
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
                SqlParameter roleParam = new SqlParameter("@roleId", user.RoleId);
                command.Parameters.Add(roleParam);
                SqlParameter idParam = new SqlParameter("@id", user.Id);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
                Console.WriteLine("Обновлен объект");
            }
        }
    }
}
