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
            return _context.Users.Include(a => a.Accounts).ToList();
        }

        public User GetUser(string fullName)
        {
            return _context.Users.Include(a => a.Accounts).ThenInclude(a => a.InvestmentTransactions).FirstOrDefault(a => a.FullName == fullName);
        }
    }
}