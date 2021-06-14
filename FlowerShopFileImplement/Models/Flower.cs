﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopFileImplement.Models
{
    public class Flower
    {
        public int Id { get; set; }
        public string FlowerName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> FlowerComponents { get; set; }
    }
}