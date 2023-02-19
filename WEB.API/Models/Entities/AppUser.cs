using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.API.Models.Entities
{
    public class AppUser:BaseEntity
    {
      
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}