using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult CreateCheckoutSession()
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = 2000,
                            Currency = "sek",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "T-shirt",
                            },

                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = "https://example.com/success",
                CancelUrl = "https://example.com/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return new JsonResult(new { id = session.Id });

        }
    }
}
