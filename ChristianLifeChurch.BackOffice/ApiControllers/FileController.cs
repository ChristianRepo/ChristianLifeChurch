using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace ChristianLifeChurch.BackOffice.ApiControllers
{
    public class FileController : ApiController
    {

        [HttpPost]
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = GetMultipartProvider();
            var task = await Request.Content.ReadAsMultipartAsync(provider);

            var originalFileName = GetDeserialisedFileName(task.FileData.First());

            var uploadedFileInfo = new FileInfo(task.FileData.First().LocalFileName);
            uploadedFileInfo.CopyTo(Path.Combine(GetUploadFolder(), originalFileName), true);
            uploadedFileInfo.Delete();
            
            return this.Request.CreateResponse(HttpStatusCode.OK, originalFileName);

        }

        private string GetUploadFolder()
        {
            const string uploadFolder = "~/Content/fotoOfMembers";

            var path = HttpContext.Current.Server.MapPath(uploadFolder);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        private MultipartFormDataStreamProvider GetMultipartProvider()
        {
            const string uploadFolder = "~/Content/temp";
            var path = HttpContext.Current.Server.MapPath(uploadFolder);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return new MultipartFormDataStreamProvider(path);
        }

        private string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }

        private string GetDeserialisedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }
    }
}
