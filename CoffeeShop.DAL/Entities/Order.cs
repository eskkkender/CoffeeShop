using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public decimal Sum { get; set; }

        public string Phone { get; set; }

        public int CoffeId { get; set; }

        public Coffee Coffee { get; set;}

        public DateTime Date { get; set; }
    }
}
