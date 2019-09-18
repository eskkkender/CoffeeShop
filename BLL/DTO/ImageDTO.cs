using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ImageDTO
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public int ProductId { get; set; }

        public ProductDTO Product { get; set; }

    }
}
