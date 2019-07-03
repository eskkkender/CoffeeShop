using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        /// <summary>
        /// Наименовние кофе
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание кофе
        /// </summary>
        public string Description { get; set; }
    }
}