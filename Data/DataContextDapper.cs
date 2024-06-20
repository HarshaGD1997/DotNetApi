using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace DotNetApiCreate.Data
{
    public class DataContextDapper
    {

        private readonly IConfiguration _config;
        private readonly IDbConnection _dbConnection;

        public DataContextDapper(IConfiguration config)
        {
            _config = config;
            _dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }


        public IEnumerable<T> LoadData<T>(string sql)
        {
            return _dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle <T>(string sql)
        {
            return _dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            return _dbConnection.Execute(sql) >0 ;
        }

        public int ExecuteSqlRowCount(string sql)
        {
            return _dbConnection.Execute(sql);
        }
    }

}