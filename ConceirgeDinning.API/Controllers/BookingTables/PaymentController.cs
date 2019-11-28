﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceirgeDining.Middleware;
using ConceirgeDining.Middleware.BookingTable;
using ConceirgeDiningDAL.Models;
using ConceirgeDinning.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace ConceirgeDinning.API.Controllers.BookingTable
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PaymentResponse> StartPayment([FromBody]JObject jObject)
        {
            try
            {
                int bookingId = Convert.ToInt32(jObject["bookingId"]);
                long pointBalance = Convert.ToInt64(jObject["pointBalance"]);
                string restaurantName = Convert.ToString(jObject["restaurantName"]);

                PaymentInitialiser paymentInitialisation = new PaymentInitialiser(bookingId);
                PaymentResponse paymentResponse = new PaymentResponse();
                paymentResponse = paymentInitialisation.Validation(pointBalance);
                if (paymentResponse.Status == "Booking Possible")
                    paymentResponse = paymentInitialisation.Start();
                paymentResponse.RestaurantName = restaurantName;
                Log.Information("Status : payment Done \nRequest from user : " + jObject + "\nResponse to User :" + JsonConvert.SerializeObject(paymentResponse));
                return paymentResponse;
            }
            catch (Exception e)
            {
                Log.Error("Status : payment Failed \nRequest from user : " + jObject + "\nResponse to User :  null" + "\nError :"  + e.Message);
                return Conflict();
            }
            
        }
        
        
    }
}