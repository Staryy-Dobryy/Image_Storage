using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Tools
{
    public class ImageHandlerTool
    {
        public async Task SaveImageAsync(IFormFile image, string webRootPath, string imageUrl)
        {
            using (var fileStream = new FileStream(webRootPath + imageUrl, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
        }

        public void DeleteImage(string webRootPath, string imageUrl)
        {
            FileInfo fileInfo = new FileInfo(webRootPath + imageUrl);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}
