using System.Collections.Generic;
using System.Linq;

namespace Task2_StructuralPatterns_Client
{
    public class ActiveEntitiesFilter : IEntityFilter
    {
        public IEnumerable<SomeEntity> Apply(IEnumerable<SomeEntity> items)
        {
            return items.Where(e => e.Status == 1);
        }
    }
}

