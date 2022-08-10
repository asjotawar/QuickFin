using System;
using Microsoft.EntityFrameworkCore;
using QuickFin.Models;

namespace DataAccessLayer.DAL_Classes
{
    public class User_DAL
    {
        private string _connectionString;
        private readonly QuickFinDbContext _context;

        public User_DAL(string connectionString)
        {
            _connectionString = connectionString;
            _context = new QuickFinDbContext(connectionString);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}