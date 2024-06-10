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
    
    public UserController(IConfiguration configuration) {

        _dapper = new DataContextDapper(configuration);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
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

