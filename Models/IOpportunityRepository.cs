using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public interface IOpportunityRepository
    {
        IEnumerable<Opportunity> Opportunities { get; }
    }
}


