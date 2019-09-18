using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ImageViewModel
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }
    }
}