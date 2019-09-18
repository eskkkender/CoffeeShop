﻿using System.Collections.Generic;

namespace DTO
{
    public class ProductDTO: BaseDTO
    {
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        public string FileUrl { get; set; }

        public ICollection<ImageDTO> Images { get; set; } = new List<ImageDTO>();
    }
}
