using KSocial.Data.Helpers.Constants;
using KSocial.Data.Models;
using KSocial.Data.Services.Interfaces;
using KSocial.ViewModels.Friends;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KSocial.ViewComponents
{
    public class SuggestedFriendsViewComponent : ViewComponent
    {
        private readonly IFriendsService _friendsService;
        private readonly UserManager<User> _userManager;

        public SuggestedFriendsViewComponent(IFriendsService friendsService, UserManager<User> userManager)
        {
            _friendsService = friendsService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUserId = ((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = int.Parse(loggedInUserId!);

            var suggestedFriends = await _friendsService.GetSuggestedFriendsAsync(userId);
            var suggestedFriendsVM = suggestedFriends
                .Where(n => !_userManager.IsInRoleAsync(n.User, AppRoles.Admin).Result)
                .Select(n => new UserWithFriendsCountVM()
            {
                UserId = n.User.Id,
                FullName = n.User.FullName,
                ProfilePictureUrl = n.User.ProfilePictureUrl,
                FriendsCount = n.FriendsCount
            }).ToList();

            return View(suggestedFriendsVM);
        }
    }
}
