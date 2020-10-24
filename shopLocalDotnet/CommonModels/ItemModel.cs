﻿using System;

namespace shopLocalCommonModels
{
    public class ItemModel
    {
       
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
    }
}
