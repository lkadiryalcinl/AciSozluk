using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Domain.Entities
{
    public class Title
    {
        public Guid TitleID { get; set; }
        public string TitleName { get; set; }
        public Channel Channel { get; set; }
        public Guid ChannelId { get; set; }
    }
}
