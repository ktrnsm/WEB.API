using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.API.DesignPatterns.SingletonPattern;
using WEB.API.Models.Context;
using WEB.API.Models.Entities;
using WEB.API.Tools;

namespace WEB.API.Controllers
{
    public class HomeController:Controller
    {
        MyContext _db;

        public HomeController()
        {
            _db = DBTool.DBInstance;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AppUser appUser)
        {
            MailService.Send(appUser.Email, body: "Welcome to TEKNOROMA", subject: "Please start to do Shopping");
            ViewBag.Mesage = "Email has been successfully sent";

                return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}