using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkovdePizzaApi.Models;

namespace SkovdePizzaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        public PaymentsController()
        {
            StripeConfiguration.ApiKey = "sk_test_51I6bvkHTHUtbDw8mkUTk68c6Vgv5BivdJLpbD1mL4Rt31id6jbfZhc3gUBozyEXB8CnhoRIDuwXxbzyWorxxlpVZ00ycZwM2Ih";
        }

        [HttpPost]
        public ActionResult CreateCheckoutSession([FromBody] PaymentData paymentData)
        {
            if (!ModelState.IsValid)
            {
                return new RedirectResult("http://localhost:3000");
            }
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {                        
                        Amount = paymentData.Cost * 100,
                        Currency= "sek",
                        Name = paymentData.OrderNumber,
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = "http://localhost:3000/",
                CancelUrl = "http://localhost:3000/order",
            };

            var service = new SessionService();
            var session = service.Create(options);

            return new JsonResult(new { sessionId = session.Id });

        }
    }
}
