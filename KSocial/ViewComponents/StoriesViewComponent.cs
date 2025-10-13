using KSocial.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KSocial.ViewComponents
{
    public class StoriesViewComponent : ViewComponent
    {
        private readonly IStoriesService _storiesService;
        private readonly IFriendsService _friendsService;

        public StoriesViewComponent(IStoriesService storiesService, IFriendsService friendsService)
        {
            _storiesService = storiesService;
            _friendsService = friendsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Lấy userId hiện tại
            var loggedInUserId = int.Parse(((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier)!);

            // Lấy danh sách bạn bè
            var friendships = await _friendsService.GetFriendsAsync(loggedInUserId);
            var friendIds = friendships
                .Select(f => f.SenderId == loggedInUserId ? f.ReceiverId : f.SenderId)
                .ToList();

            // Nếu muốn hiển thị cả stories của chính mình:
            friendIds.Add(loggedInUserId);

            // Lấy tất cả stories
            var allStories = await _storiesService.GetAllStoriesAsync();
            var now = DateTime.UtcNow;
            var recentStories = allStories
                .Where(s => s.DateCreated.AddHours(24) >= now && friendIds.Contains(s.UserId))
                .OrderByDescending(s => s.DateCreated)
                .ToList();

            return View(recentStories);
        }
    }
}
