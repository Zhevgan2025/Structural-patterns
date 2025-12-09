using System.Collections.Generic;
using System.Linq;

namespace Task2_StructuralPatterns_Client
{
    public class NameContainsFilter : IEntityFilter
    {
        private readonly string _substring;

        public NameContainsFilter(string substring)
        {
            _substring = substring ?? string.Empty;
        }

        public IEnumerable<SomeEntity> Apply(IEnumerable<SomeEntity> items)
        {
            var lower = _substring.ToLower();

            return items.Where(e =>
                !string.IsNullOrEmpty(e.Name) &&
                e.Name.ToLower().Contains(lower));
        }
    }
}

