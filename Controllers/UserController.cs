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


    [HttpGet("GetUsers")]
    //public IActionResult Test()
    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users;
        string sql = @"
            SELECT * FROM TutorialAppSchema.Users
        ";
        users = _dapper.LoadData<User>(sql);
        return users;
        
    }

    [HttpGet("GetSingleUser/{UserId}")]
    //public IActionResult Test()
    public User GetSingleUser(int UserId)
    {
        User user;
        string sql = $@"
                        SELECT * FROM tutorialAppSchema.Users where UserId = {UserId}
        ";
        user = _dapper.LoadDataSingle<User>(sql);
        return user;
    }

}

