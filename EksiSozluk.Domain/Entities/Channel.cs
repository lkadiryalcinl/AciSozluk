using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Domain.Entities
{
    public class Channel
    {
        public Guid ChannelID { get; set; }
        public string ChannelName { get; set; }
        public List<Title> Titles { get; set; }
     
    }
}
