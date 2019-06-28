﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BLL.BusinessModels
{
    public class Discount
    {
        private decimal _value = 0;
        public Discount(decimal val) 
        {
            _value = val;
        }
        
        public decimal Value { get { return _value; } }
        public decimal GetDiscountedPrice(decimal sum)
        {
            if (DateTime.Now.Day == 1)
                return sum - sum * _value;
            return sum;
        }
    }
}
