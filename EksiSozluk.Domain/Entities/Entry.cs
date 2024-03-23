using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Domain.Entities
{
    public class Entry
    {
        public Guid Id { get; set; }

        public string EntryContent { get; set; }

        public int LikeCount { get; set; } = 0;

        public int FavoriteCount { get; set; } = 0;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsEntryLiked { get; set; } = false;

        public bool IsEntryDisliked { set; get; } = false;

        public bool IsEntryDelete { get; set; } = false;

        public bool IsEntryUpdated { get; set; } = false;

        public bool IsEntryFavorited { get; set; } = false;

        // Entry has to belong to one user
        // Followed Entry list belong to one user
        public string UserId { get; set; }

        public User User { get; set; }
        // Entry has to belong to one title
        public Guid TitleId { get; set; }

        public Title Title { get; set; }
    }
}
