using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Base
{
    public abstract class EntityIdBase
    {
        /// <summary>
        /// Индентификатор
        /// </summary>
        public long Id { get; set; }
    }
}
