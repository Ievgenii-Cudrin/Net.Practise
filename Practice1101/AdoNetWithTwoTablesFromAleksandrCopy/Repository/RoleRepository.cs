﻿using AdoNetWithTwoTablesFromAleksandr0102.Entities;
using AdoNetWithTwoTablesFromAleksandr0102.Interfaces;
using AdoNetWithTwoTablesFromAleksandrCopy.Helpers;
using AdoNetWithTwoTablesFromAleksandrCopy.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetWithTwoTablesFromAleksandr0102.Repository
{
    public class RoleRepository : IRoleRepository
    {
        IConnection connection;
        static string connectionString;

        public RoleRepository(IConnection connection)
        {
            this.connection = connection;
            connectionString = this.connection.ConnectionString;
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
    }
}