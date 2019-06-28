using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }

        public int CoffeeId { get; set; }

        public DateTime? Date { get; set; }

    }
}
