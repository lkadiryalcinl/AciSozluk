using EksiSozluk.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Application.Mediator.Commands.Profile
{
    public class RemoveProfileEntryCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool IsEntryDelete { get; set; } = false;
    }
}
