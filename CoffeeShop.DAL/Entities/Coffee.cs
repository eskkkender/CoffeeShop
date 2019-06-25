using CoffeeShop.DAL.Entities;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoffeeShop.DAL
{
    public class Coffee
    {
        /// <summary>
        /// Ид товара кофе
        /// </summary>
        public int CoffeeId { get; set; }
        /// <summary>
        /// Наименовние кофе
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание кофе
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Цена кофе
        /// </summary>
        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}