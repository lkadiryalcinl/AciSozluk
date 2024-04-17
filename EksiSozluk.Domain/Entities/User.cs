using Microsoft.AspNetCore.Identity;

namespace EksiSozluk.Domain.Entities
{
    public class User : IdentityUser
    {
        //Id came from IdentityUserLibrary.
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[]? UserPicture { get; set; }

        public string? UserBiography { get; set; }

        public bool? UserStatus { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public EntryTransactionRelation EntryTransactionRelation { get; set; }
        // The user can write many entries
        public List<Entry> UserEntries { get; set; }
        public List<FollowChannel> FollowChannels { get; set; }
        public List<FollowTitle> FollowTitles { get; set; }
        public List<FollowUser> FollowUsers { get; set; }
    }
}