using EksiSozluk.Application.Dtos.EntryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Application.Mediator.Results.ProfileEntryResults
{
    public class GetEntriesByFilterQueryResult
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public string EntryContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Username { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
