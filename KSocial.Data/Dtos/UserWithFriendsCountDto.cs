using KSocial.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSocial.Data.Dtos
{
    public class UserWithFriendsCountDto
    {
        public User User { get; set; }
        public int FriendsCount { get; set; }
    }
}
