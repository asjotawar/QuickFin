using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickFin.Models;
using Microsoft.Extensions.Configuration;
using DataAccessLayer.DAL_Classes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IConfiguration _configuration;
    private BusinessLogicLayer.Bll_Classes.User_BLL User_BLL;

    public UserController(ILogger<UserController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        string connectionString = _configuration.GetConnectionString("QuickFinCS");
        User_BLL = new BusinessLogicLayer.Bll_Classes.User_BLL(connectionString);
    }

    // GET: /<controller>/
    [HttpGet("GetAllUsers")]
    public IEnumerable<User> Index()
    {
        return User_BLL.GetUsers();
    }
    //GET: /<controller>/
    [HttpGet("GetUserDetails")]
    public ActionResult<User> GetUser([FromQuery]User user)
    {
        var userDetails = User_BLL.GetUser(user.FullName);
        if(userDetails != null && user.Password == userDetails.Password)
        {
            return userDetails;
        }
        else
        {
            return NotFound();
        }
    }
}

