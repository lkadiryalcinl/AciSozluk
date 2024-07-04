using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Domain.Entities
{
    public class EntryTransaction
    {
        public Guid Id { get; set; }
        public DateTime FavoritedDate { get; set; }
        public DateTime LikedDate { get; set; }
        public DateTime DisikedDate { get; set; }
        public bool IsFavorited { get; set; }
        public bool IsLiked { get; set; }
        public bool IsDisliked { get; set; }
        public EntryTransactionRelation EntryTransactionRelation { get; set; }
    }
}
