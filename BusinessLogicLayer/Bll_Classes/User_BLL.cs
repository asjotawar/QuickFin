using System;
using DataAccessLayer.DAL_Classes;
using QuickFin.Models;

namespace BusinessLogicLayer.Bll_Classes
{
    public class User_BLL
    {
        private readonly string _connectionString;
        private User_DAL user_DAL;

        public User_BLL(string connectionString)
        {
            _connectionString = connectionString;
            user_DAL = new User_DAL(_connectionString);
        }

        public List<User> GetUsers()
        {
            return user_DAL.GetUsers();
        }

    }
}

