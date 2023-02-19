using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;
using WEB.API.Models.Entities;
using WEB.API.Models.Inıt;

namespace WEB.API.Models.Context
{
    public class MyContext:DbContext

    {
        public MyContext():base("MyConnection")
        {
            Database.SetInitializer(new MyInit());
        }
        public DbSet<CardInfo> Cards { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}