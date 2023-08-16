using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;

namespace Restaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CloudinaryController : ControllerBase
    {

        private readonly ICloudinaryService _cloudinaryService;

        public CloudinaryController(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }


        [HttpPost("upload")]
        public IActionResult UploadImage(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("Invalid file");
            }

            var cloudinary = _cloudinaryService.GetCloudinaryInstance();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            if (uploadResult.Error != null)
            {
                return BadRequest($"Upload failed: {uploadResult.Error.Message}");
            }

            var imageUrl = uploadResult.SecureUri.ToString(); 

            return Ok(new { ImageUrl = imageUrl });
        }


        [HttpGet("getall")]
        public IActionResult GetAllImages()
        {
            var cloudinary = _cloudinaryService.GetCloudinaryInstance();

            var result = cloudinary.ListResources(new ListResourcesByTagParams { Tag = "Product" });

            if (result.Error != null)
            {
                return BadRequest($"Error fetching images: {result.Error.Message}");
            }

            var imageUrls = new List<string>();
            foreach (var resource in result.Resources)
            {
                imageUrls.Add(resource.SecureUrl.ToString());
            }

            return Ok(imageUrls);
        }


    }
}
