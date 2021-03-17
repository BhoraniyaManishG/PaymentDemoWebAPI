using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentDemoService.IServices;
using PaymentDemoService.Util;
using PaymentDemoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentProcess service;

        public PaymentController(IPaymentProcess service, ILogger<PaymentController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        // GET: api/<PaymentController>
        [HttpGet]
        public string Get()
        {
            return "Please use POST";
        }

        // POST api/<PaymentController>
        [HttpPost]
        public IActionResult Post(PaymentRequestVM paymentRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    paymentRequest.ExpirationDate = new DateTime(paymentRequest.ExpirationDate.Year,paymentRequest.ExpirationDate.Month,1);

                    PaymentStatusVM result = service.ProcessPaymentRequest(paymentRequest);

                    if (result.PaymentStatus == Enums.PaymentProcessStatus.processed.ToString())
                    {
                        return Ok("Payment is processed");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process payment");
                    }
                }
                else
                {
                    return BadRequest("Invalid inputs");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "Internal server error exception raised");
            }
        }


    }
}
