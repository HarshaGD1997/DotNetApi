using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;

namespace DotNetApiCreate.Controllers;

//tag to help send and receive Json data
[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly DataContextDapper _dapper;

    //private readonly DBCreate _db;
    
    public UserController(IConfiguration configuration) {

        _dapper = new DataContextDapper(configuration);
        int schemaTableStat = _dapper.ExecuteSqlRowCount("IF EXISTS (SELECT * FROM sys.schemas WHERE name = 'EmployeeSchema') SELECT 1 ELSE SELECT 0");

        if (schemaTableStat == 0)
        {
            _dapper.ExecuteSql("CREATE SCHEMA EmployeeSchema");
        }

        int tableStat = _dapper.ExecuteSqlRowCount("IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employee' AND TABLE_SCHEMA = 'EmployeeSchema') SELECT 1 ELSE SELECT 0");

        if (tableStat == 0)
        {
            _dapper.ExecuteSql("");
        }
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("TestTable")]
    public bool TableStat() {

        return _dapper.ExecuteSql("IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employee' AND TABLE_SCHEMA = 'EmployeeSchema') SELECT 1 ELSE SELECT 0");
    }

    [HttpGet("GetUsers/{parameterVal}")]
    //public IActionResult Test()
    public string[] GetUsers(string parameterVal)
    {
        string[] response = new string[] {
            "test1",
            "test2",
            "test3",
            parameterVal
        };
        return response;
    }


}

