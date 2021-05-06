using Produce300.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Produce300.Context
{
    public class UInfo : DbContext
    {
        public UInfo() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baemung\Documents\KOSTA_Project\Produce300\db.mdf;Integrated Security=True;Connect Timeout=30")
        { }
        public DbSet<User> UserInfo { get; set; }
    }
}