using KSocial.Data.Dtos;
using KSocial.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSocial.Data.Services.Interfaces
{
    public interface IFriendsService
    {
        Task SendRequestAsync(int senderId, int receiverId);
        Task<FriendRequest> UpdateRequestAsync(int requestId, string status);
        Task RemoveFriendAsync(int frienshipId);
        Task<List<UserWithFriendsCountDto>> GetSuggestedFriendsAsync(int userId);

        Task<List<FriendRequest>> GetSentFriendRequestAsync(int userId);
        Task<List<FriendRequest>> GetReceivedFriendRequestAsync(int userId);
        Task<List<Friendship>> GetFriendsAsync(int userId);
    }
}
