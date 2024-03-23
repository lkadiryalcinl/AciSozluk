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

        // Followings list -> many to many relation with using user list
        public List<User> Followings { get; set; }
        // Followers list -> many to many relation with using user list
        public List<User> Followers { get; set; }
        // The user can write many entries
        public List<Entry> UserEntries { get; set; }
        // Followed channels these personal
        public List<Channel> FollowedChannels { get; set; }
        // Followed titles these personal 
        public List<Title> FollowedTitles { get; set; }
    }
}