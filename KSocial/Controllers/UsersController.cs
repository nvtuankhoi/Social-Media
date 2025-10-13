using KSocial.Controllers.Base;
using KSocial.Data.Helpers.Constants;
using KSocial.Data.Models;
using KSocial.Data.Services.Interfaces;
using KSocial.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KSocial.Controllers
{
    [Authorize(Roles = AppRoles.User)]
    public class UsersController : BaseController
    {
        private readonly IUsersService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IFriendsService _friendsService;
        public UsersController(IUsersService usersService, UserManager<User> userManager, IFriendsService friendsService)
        {
            _userService = usersService;
            _userManager = userManager;
            _friendsService = friendsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var userPosts = await _userService.GetUserPosts(userId);

            var friendships = await _friendsService.GetFriendsAsync(userId);
            var friends = friendships
                .Select(f => f.SenderId == userId ? f.Receiver : f.Sender)
                .ToList();
            var userProfileVM = new GetUserProfileVM()
            {
                User = user,
                Posts = userPosts,
                Friends = friends
            };

            return View(userProfileVM);
        }
    }
}
