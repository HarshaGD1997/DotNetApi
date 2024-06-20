using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Linq;
using DotNetApiCreate.Dtos;
using DotNetApiCreate.Data;
using DotNetApiCreate.Models;

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

    [HttpPut("UpdateUserFromId")]
    public IActionResult UpdateUserFromId(User user)
    {
        string sql = $@" UPDATE  tutorialAppSchema.Users SET FirstName = '{user.FirstName}'
        , LastName = '{user.LastName}'
        , Email = '{user.Email}'
        , Gender = '{user.Gender}'
        , Active = '{user.Active}'
        WHERE UserId = {user.UserId}";

        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("failed to update user");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserDto user) {                                        //adding Dto user model to exclude Id field 
    string sql = $@" INSERT INTO  tutorialAppSchema.Users( 
    FirstName,
    LastName,
    Email,
    Gender,
    Active) VALUES (
    '{user.FirstName}'
    ,'{user.LastName}'
    ,'{user.Email}'
    ,'{user.Gender}'
    ,'{user.Active}'
    )";

    Console.WriteLine(sql);

    if (_dapper.ExecuteSql(sql))
    {
        return Ok();
    }

    throw new Exception("failed to create user");
    }

}

