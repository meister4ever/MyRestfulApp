using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyRestfulApp.Models
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        public void MarkAsModified(User user)
        {
            Entry(user).State = EntityState.Modified;
        }
    }
}   
