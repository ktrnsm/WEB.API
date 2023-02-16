using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WEB.API.DesignPatterns.SingletonPattern;
using WEB.API.DTOClasses;
using WEB.API.Models.Context;
using WEB.API.Models.Entities;

namespace WEB.API.Controllers
{
    public class PaymentController:ApiController
    {
        MyContext _db;
        public PaymentController()
        {
            _db = DBTool.DBInstance;
        }

        void SetBalance(PaymentDTO item, CardInfo ci)
        {
            ci.Balance -= item.ShoppingPrice;
            _db.SaveChanges();
        }



        [HttpPost]

        public IHttpActionResult RecievePayment(PaymentDTO item)
        {
            CardInfo ci = _db.Cards.FirstOrDefault(x => x.CardNumber == item.CardNumber && x.SecurityNumber == item.SecurityNumber && x.CardUserName == item.CardUserName && x.CardExpiryYear == item.CardExpiryYear && x.CardExpiryMonth == item.CardExpiryMonth);

            

            if(ci!=null)
                if(ci.CardExpiryYear<DateTime.Now.Year)
                {
                    return BadRequest("Card is Expired");
                }
            else if(ci.CardExpiryYear==DateTime.Now.Year)
                {
                    if(ci.CardExpiryMonth<DateTime.Now.Month)
                    {
                        return BadRequest("Card is Month-wisely Expired");
                    }
                    if(ci.Balance>=item.ShoppingPrice)
                    {
                        SetBalance(item, ci);
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Balance is not Enough");
                    }
                }
            return BadRequest("Card is not findable");


        }
    }
}