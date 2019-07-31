using System.Collections.Generic;
using DTO;

namespace BLL.Interfaces
{
    public interface IProductManager
    {
        ProductDTO GetProductId( int id);
        /// <summary>
        /// Добавляет товар
        /// </summary>
        void AddProduct(ProductDTO item);

        /// <summary>
        /// Возвращает весь товар
        /// </summary>
        List<ProductDTO> GetAllProducts ();
    }
}