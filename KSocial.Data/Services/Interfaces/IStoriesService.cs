using KSocial.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSocial.Data.Services.Interfaces
{
    public interface IStoriesService
    {
        Task<List<Story>> GetAllStoriesAsync();
        Task<Story> CreateStoryAsync(Story story);
    }
}
