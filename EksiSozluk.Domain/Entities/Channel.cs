using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Domain.Entities
{
    public class Channel
    {
        public Guid Id { get; set; }

        public string ChannelName { get; set; }

        public string ChannelDescription { get; set; }

        public bool IsFollowed { get; set; } = false;
        // The following channel list belong to one user
        public string UserId { get; set; }

        public User User { get; set; }
        // The channel can have many titles
       public List<Title> Titles { get; set; }
    }
}
