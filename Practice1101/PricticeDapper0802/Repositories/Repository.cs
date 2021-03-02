using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using PricticeDapper0802.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Dapper;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace PricticeDapper0802.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        string name = typeof(T).Name;

        private SqlConnection SqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        public async Task Add(T item)
        {
            using (var connection = CreateConnection())
            {
                await connection.InsertAsync<T>(item);
            }
        }

        public async Task<T> FindByID(int id)
        {
            return await CreateConnection().GetAsync<T>(id);
        }

        public async Task Delete(T entity)
        {
            await CreateConnection().DeleteAsync<T>(entity);
        }

        public async Task Update(T entity)
        {
            using (var connection = CreateConnection())
            {
                await connection.UpdateAsync<T>(entity);
            }
        }
    }
}
