using KSocial.Data.Helpers.Enums;
using KSocial.Data.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSocial.Data.Services
{
    public class FilesService : IFilesService
    {
        private readonly string _basePath;

        public FilesService(string basePath)
        {
            _basePath = basePath;
        }

        public async Task<string> UploadImageAsync(IFormFile file, ImageFileType imageFileType)
        {
            string folderName = imageFileType switch
            {
                ImageFileType.PostImage => "posts",
                ImageFileType.StoryImage => "stories",
                ImageFileType.ProfilePicture => "profiles",
                _ => throw new ArgumentException("Invalid file type")
            };

            if (file == null || file.Length == 0)
                return "";

            string directoryPath = Path.Combine(_basePath, folderName);
            Directory.CreateDirectory(directoryPath);

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(directoryPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine(folderName, fileName).Replace("\\", "/");
        }
    }
}
