using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PaymentDemoAPI;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PaymentDemoViewModelsTest
{
    public class PaymentControllerUnitTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> _webApplicationFactory;
        HttpClient _client;

        public PaymentControllerUnitTest(WebApplicationFactory<Startup> fixture)
        {
            this._webApplicationFactory = fixture;
            this._client = this._webApplicationFactory.CreateClient();
        }

        [Fact]
        public void Get_Payment_Ok()
        {
            var response = _client.GetAsync("/api/Payment");
            response.Result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_Payment_CheapPayment_success()
        {
            var o = new PaymentDemoViewModels.PaymentRequestVM()
            {
                CreditCardNumber = "4111111111111111",
                Amount = 2,//Even for success result
                CardHolder = "TEST USER",
                ExpirationDate = DateTime.Today.AddYears(1),
                SecurityCode = "555"
            };

            var response = await _client.PostAsync("/api/Payment", new StringContent(JsonConvert.SerializeObject(o), System.Text.Encoding.UTF8, mediaType: "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.ReadAsStringAsync().Equals("Payment is processed");
        }

        [Fact]
        public async Task Post_Payment_CheapPayment_fail()
        {
            var o = new PaymentDemoViewModels.PaymentRequestVM()
            {
                CreditCardNumber = "4111111111111111",
                Amount = 3,//Odd for failure result
                CardHolder = "TEST USER",
                ExpirationDate = DateTime.Today.AddYears(1),
                SecurityCode = "555"
            };

            var response = await _client.PostAsync("/api/Payment", new StringContent(JsonConvert.SerializeObject(o), System.Text.Encoding.UTF8, mediaType: "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

            response.Content.ReadAsStringAsync().Equals("Unable to process payment");
        }

        [Fact]
        public async Task Post_Payment_ExpensivePayment_success()
        {
            var o = new PaymentDemoViewModels.PaymentRequestVM()
            {
                CreditCardNumber = "4111111111111111",
                Amount = 22,//Even for success result
                CardHolder = "TEST USER",
                ExpirationDate = DateTime.Today.AddYears(1),
                SecurityCode = "555"
            };

            var response = await _client.PostAsync("/api/Payment", new StringContent(JsonConvert.SerializeObject(o), System.Text.Encoding.UTF8, mediaType: "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.ReadAsStringAsync().Equals("Payment is processed");
        }

        [Fact]
        public async Task Post_Payment_ExpensivePayment_fail()
        {
            var o = new PaymentDemoViewModels.PaymentRequestVM()
            {
                CreditCardNumber = "4111111111111111",
                Amount = 23,//Odd for failure result
                CardHolder = "TEST USER",
                ExpirationDate = DateTime.Today.AddYears(1),
                SecurityCode = "555"
            };

            var response = await _client.PostAsync("/api/Payment", new StringContent(JsonConvert.SerializeObject(o), System.Text.Encoding.UTF8, mediaType: "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

            response.Content.ReadAsStringAsync().Equals("Unable to process payment");
        }

        [Fact]
        public async Task Post_Payment_PremiumPayment_success()
        {
            var o = new PaymentDemoViewModels.PaymentRequestVM()
            {
                CreditCardNumber = "4111111111111111",
                Amount = 2222,//Even for success result
                CardHolder = "TEST USER",
                ExpirationDate = DateTime.Today.AddYears(1),
                SecurityCode = "555"
            };

            var response = await _client.PostAsync("/api/Payment", new StringContent(JsonConvert.SerializeObject(o), System.Text.Encoding.UTF8, mediaType: "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.ReadAsStringAsync().Equals("Payment is processed");
        }

        [Fact]
        public async Task Post_Payment_PremiumPayment_fail()
        {
            var o = new PaymentDemoViewModels.PaymentRequestVM()
            {
                CreditCardNumber = "4111111111111111",
                Amount = 2223,//Odd for failure result
                CardHolder = "TEST USER",
                ExpirationDate = DateTime.Today.AddYears(1),
                SecurityCode = "555"
            };

            var response = await _client.PostAsync("/api/Payment", new StringContent(JsonConvert.SerializeObject(o), System.Text.Encoding.UTF8, mediaType: "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

            response.Content.ReadAsStringAsync().Equals("Unable to process payment");
        }
    }



}
