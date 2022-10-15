using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace saitynai_server.Controllers
{
    [Route("api/v1/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        public const string _defaultImage = "default.jpg";
        private const string _folderName = "Files";
        private const string _saveExtension = ".jpg";
        private readonly string[] _acceptedExtensions = new string[] { ".jpg", ".png", ".jpeg", ".webp" };

        [HttpPost]
        public async Task<ActionResult<string>> Upload(List<IFormFile> files)
        {
            StringBuilder fileNames = new StringBuilder();

            if (files != null && files.Count > 0)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), _folderName);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                foreach (var file in files)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (!_acceptedExtensions.Contains(fileExtension))
                        return BadRequest($"'{file.FileName}' extension is not allowed. Allowed extensions are: '{string.Join(", ", _acceptedExtensions)}'.");

                    string randomName = Path.GetRandomFileName();
                    randomName = Path.ChangeExtension(randomName, _saveExtension);

                    string fileNameWithPath = Path.Combine(path, randomName);

                    try
                    {
                        using (var stream = System.IO.File.Create(fileNameWithPath))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, $"File(s) failed to upload to server with an exception: '{ex.Message}'");
                    }

                    fileNames.Append(randomName);
                    fileNames.Append(';');
                }

                fileNames.Length--;
                return Created($"/api/v1/files", fileNames.ToString());
            }
            else
            {
                return BadRequest("No files to be uploaded found.");
            }
        }

        public static void Delete(string oldPhotos)
        {
            if (oldPhotos == null || oldPhotos == _defaultImage) 
                return;

            string[] fileNames = oldPhotos.Split(';');
            string path = Path.Combine(Directory.GetCurrentDirectory(), _folderName);
            try
            {
                foreach (string fileName in fileNames)
                {
                    System.IO.File.Delete(Path.Combine(path, fileName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File(s) failed to be deleted from server with an exception: '{ex.Message}'");
            }
        }
    }


}
