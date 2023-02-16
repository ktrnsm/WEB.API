using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEB.API.Models.Context;
using WEB.API.Models.Entities;

namespace WEB.API.Models.Inıt
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            CardInfo ci = new CardInfo();
            ci.CardUserName = "Semih Iktüeren";
            ci.CardExpiryYear = 2030;
            ci.CardExpiryMonth = 07;
            ci.SecurityNumber = "123";
            ci.Limit = 1000;
            ci.Balance = 1000;
            context.Cards.Add(ci);
            context.SaveChanges();

        }
    }
}