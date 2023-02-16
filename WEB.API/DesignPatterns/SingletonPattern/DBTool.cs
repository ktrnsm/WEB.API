using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.API.Models.Context;

namespace WEB.API.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        public static MyContext DBInstance { get; internal set; }
    }
}