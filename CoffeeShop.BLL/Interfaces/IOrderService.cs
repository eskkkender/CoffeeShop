using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeShop.BLL.DTO;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.BLL.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// получение всё кофе для выбора товара
        /// </summary>
        void MakeOrder(OrderDTO orderDto);

        /// <summary>
        /// выбор кофе для заказа
        /// </summary>
        CoffeeDTO GetCoffee(int? id);

        /// <summary>
        /// оформление заказа
        /// </summary>
        IEnumerable<CoffeeDTO> GetCoffees();

        void Dispose();
    }
}
