using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSocial.Data.Services.Interfaces
{
    public interface IHashtagsService
    {
        Task ProcessHashtagsForNewPostAsync(string content);
        Task ProcessHashtagsForRemovedPostAsync(string content);
    }
}
