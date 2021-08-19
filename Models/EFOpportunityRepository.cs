using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AuthSystem.Models
{
    public class EFOpportunityRepository : IOpportunityRepository
    {
        private OpportunityModelContext context;
        public EFOpportunityRepository(OpportunityModelContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Opportunity> Opportunities => context.Opportunities;

    }
}