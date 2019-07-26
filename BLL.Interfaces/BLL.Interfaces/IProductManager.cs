using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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