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
using System.Linq.Expressions;
using PricticeDapper0802.Entities;

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

        public async Task<T> GetEntityByString(string table, string indicator, string stringFoFind)
        {
            using (var connection = CreateConnection())
            {
                var parameters = new { Table = table, StringForFind = stringFoFind, Indicator = indicator };
                var sql = "select * from @Table where @Indicator = @StringForFind";
                return (T)await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<IEnumerable<T>> GetAll(Pager pager, string tableName)
        {
            var parameters = new { Table = tableName, Offset = pager.Offset, Next = pager.Next };
            var sql = (@" select * from @Table
                      order by Id
                      OFFSET      @Offset ROWS 
                      FETCH NEXT  @Next   ROWS ONLY");

            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<T>(sql, parameters);
            }
        }

        public async Task<int> GetCountInTable(string tableName)
        {
            using (var connection = CreateConnection())
            {
                var parameters = new { Table = tableName };
                var sql = "SELECT COUNT(*) FROM @Table";
                return await connection.ExecuteScalarAsync<int>(sql, parameters);
            }
        }
    }
}
