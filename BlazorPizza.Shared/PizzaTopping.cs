﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorPizza.Shared
{
    public class PizzaTopping
    {
        public Topping Topping { get; set; }
        public int ToppingId { get; set; }
        public int PizzaId { get; set; }
    }
}
