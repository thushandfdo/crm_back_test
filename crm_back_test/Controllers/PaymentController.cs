using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using Stripe;

namespace crm_back_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; } = string.Empty;
        }

        public class PaymentIntentCreateRequest
        {
            [JsonProperty("items")]
            public Item[] Items { get; set; }
        }

        private int CalculateOrderAmount(Item[] items)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client
            return 5000;
        }

        [HttpPost]
        public ActionResult Create(PaymentIntentCreateRequest request)
        {
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
            {
                Amount = CalculateOrderAmount(request.Items),
                Currency = "usd",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            });

            //return Json(new { clientSecret = paymentIntent.ClientSecret });

            // Serialize the client secret into a JSON object with a "clientSecret" property.
            var responseObject = new { clientSecret = paymentIntent.ClientSecret };
            var jsonResponse = System.Text.Json.JsonSerializer.Serialize(responseObject);

            // Return the JSON response.
            return Content(jsonResponse, "application/json");
        }
    }
}
