using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebUI.Controllers
{
    public class FileUploadController : ApiController
    {
        public void Post()
        {
            //if (HttpContext.Current.Request.Files.AllKeys.Any())
            //{
            //    // Get the uploaded image from the Files collection
            //    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

            //    if (httpPostedFile != null)
            //    {
            //        // Get the complete file path
            //        String fileSavePath = HttpContext.Current.Server.MapPath("~/Content/images/") + HttpContext.Current.Request.Form["ImageName"];

            //        // Save the uploaded file to "UploadedFiles" folder
            //        httpPostedFile.SaveAs(fileSavePath);
            //    }
            //}

            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            // Check if files are available
            //if (httpRequest.Files.Count > 0)
            //{
                var files = new List<string>();

            // interate the files and save on the server

            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var filePath = HttpContext.Current.Server.MapPath("~/Content/images/" + postedFile.FileName);
                postedFile.SaveAs(filePath);

                files.Add(filePath);
            }

                // return result
                result = Request.CreateResponse(HttpStatusCode.Created, files);
            //}
            //else
            //{
            //    // return BadRequest (no file(s) available)
            //    result = Request.CreateResponse(HttpStatusCode.BadRequest);
            //}
     
        }
    }
}
