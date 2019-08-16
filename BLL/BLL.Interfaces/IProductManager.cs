using System.Collections.Generic;
using DTO;

namespace BLL.Interfaces
{
    public interface IProductManager
    {
        ProductDTO GetProductId(int id);
        /// <summary>
        /// Добавляет товар
        /// </summary>
        void AddProduct(ProductDTO item);

        /// <summary>
        /// Редактирование товара
        /// </summary>
        void EditProduct(ProductDTO item);

        /// <summary>
        /// Удаление товара
        /// </summary>
        /// <param name="item"></param>
        void DeleteProduct(int id);

        /// <summary>
        /// Возвращает весь товар
        /// </summary>
        List<ProductDTO> GetAllProducts();

    }
}