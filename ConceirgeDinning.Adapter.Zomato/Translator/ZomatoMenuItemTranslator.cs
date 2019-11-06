﻿using ConceirgeDinning.Adapter.Zomato.Models.FoodOrdering;
using ConceirgeDinning.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceirgeDinning.Adapter.Zomato.Translator
{
    public static class ZomatoMenuItemTranslator
    {
        public static List<MenuItem> GetMenuItem(MenuItems menuItem)
        {
            List<MenuItem> menuItems = new List<MenuItem>() { };

            foreach (Models.FoodOrdering.Menu item in menuItem.menu)
            {
                menuItems.Add(new MenuItem()
                {
                    Dish = item.name,
                    Price = item.price
                });
            }

            return menuItems;
        }
    }
}
