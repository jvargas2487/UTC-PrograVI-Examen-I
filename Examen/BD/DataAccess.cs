using Dapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection DbConnection => new SqlConnection(
            new SqlConnectionStringBuilder(_config.GetConnectionString("Conn")).ConnectionString
            );

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var db = DbConnection)
                {
                    await db.OpenAsync();

                    var result = db.QueryAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);

                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var db = DbConnection)
                {
                    await db.OpenAsync();

                    var result = db.QueryAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);

                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> QueryFirstAsync<T>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var db = DbConnection)
                {
                    await db.OpenAsync();

                    var result = db.QueryFirstOrDefaultAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);

                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> ExecuteAsync(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var db = DbConnection)
                {
                    await db.OpenAsync();

                    var result = await db.ExecuteReaderAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);

                    await result.ReadAsync();

                    return new()
                    {
                        CodeError = result.GetInt32(0),
                        MsgError = result.GetString(1)
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
