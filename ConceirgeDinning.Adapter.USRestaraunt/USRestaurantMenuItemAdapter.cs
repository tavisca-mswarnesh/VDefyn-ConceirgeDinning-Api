﻿using ConceirgeDinning.Adapter.USRestaraunt.Models.FoodOrdering;
using ConceirgeDinning.Contracts.Models;
using ConceirgeDinning.Adapter.USRestaraunt.Translator;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConceirgeDinning.Adapter.USRestaraunt
{
    public class USRestaurantMenuItemAdapter
    {
        public List<Category> GetMenuItems(string restaurantId)
        {
            string ApiUrl = @"https://us-restaurant-menus.p.rapidapi.com/menuitems/search";
            var request = System.Net.WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.Headers.Add("X-RapidAPI-Host", "us-restaurant-menus.p.rapidapi.com");
            request.Headers.Add("X-RapidAPI-Key", "01545b0594mshdb9591ceda3d162p1716b7jsn43e523b10b95");

            request.ContentType = "application/json";



            using (var response = request.GetResponse())
            {

                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    try
                    {
                        MenuItems menuItems = JsonConvert.DeserializeObject<MenuItems>(result);
                        Log.Information("response from supplier: " + JsonConvert.SerializeObject(result));
                        return menuItems.GetMenuItem();
                    }
                    catch (System.Net.WebException ex)
                    {
                        Log.Information("response from supplier: " + ex);
                        return null;
                    }
                }
            }
        }
    }
}
