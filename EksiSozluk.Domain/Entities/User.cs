using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace EksiSozluk.Domain.Entities
{
    public class User : IdentityUser
    {
        //Id came from IdentityUserLibrary.
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] UserPicture { get; set; }

        public string UserBiography { get; set; }

        public bool UserStatus { get; set; }

        public int FollowingCount { get; set; }

        public int FollowerCount { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<User> Followings { get; set; }
        public ICollection<User> Followers { get; set; }

        // the user can have many entries
        public List<Entry> Entries { get; set; }
        // it is following channels that personal
        public List<Channel> FollowedChannels { get; set; }
        // it is following titles that personal 
        public List<Title> FollowedTitles { get; set; }
    }
}