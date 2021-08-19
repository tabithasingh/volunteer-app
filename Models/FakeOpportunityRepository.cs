using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AuthSystem.Models
{
    public class FakeProductRepository : IOpportunityRepository
    {
        public IEnumerable<Opportunity> Opportunities => new List<Opportunity> {
    new Opportunity { Title = "Football"},
    new Opportunity { Title = "Baseball"},
    new Opportunity { Title = "Basketball"},

};
    }
}