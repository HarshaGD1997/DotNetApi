using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetApiCreate
{
    public class DBCreate
    {
        private readonly DataContextDapper _dapper;
        private readonly IConfiguration _config;

        public DBCreate(IConfiguration config)
        {
            _config = config;
            _dapper = new DataContextDapper(_config);
        }

    }


}