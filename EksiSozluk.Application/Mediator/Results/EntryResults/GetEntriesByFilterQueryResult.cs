using EksiSozluk.Application.Dtos.EntryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Application.Mediator.Results.EntryResults
{
    public class GetEntriesByFilterQueryResult
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public string EntryContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsEntryDelete { get; set; } 
        public bool IsEntryUpdated { get; set; } 

    }
}
