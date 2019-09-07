using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Product: BaseEntity<long>
    {
        public long Id { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Наименовние кофе
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание кофе
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        public string FileUrl { get; set; }
   
    }
}