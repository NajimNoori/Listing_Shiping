using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Listing_Shiping.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public char Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNUmber { get; set; }
        //public string Password { get; set; }
        //public string HashKey { get; set; }
        //public bool isActive { get; set; }
        //public DateTime DateCreated { get; set; }

    }
    public class UsersDBContext : DbContext
    {
        public UsersDBContext() : base("eBayDBCon")
        {
        }
        public DbSet<Users> User { get; set; }
    }
    
}