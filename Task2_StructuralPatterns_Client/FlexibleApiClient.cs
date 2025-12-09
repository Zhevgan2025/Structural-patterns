using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task2_StructuralPatterns_Client
{
    public class FlexibleApiClient
    {
        private readonly IOperatorApi _api;

        public FlexibleApiClient(IOperatorApi api)
        {
            _api = api;
        }

        public async Task<IEnumerable<SomeEntity>> GetByAsync(IEntityFilter filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var all = await _api.GetManyAsync();
            return filter.Apply(all);
        }

        public async Task PrintByAsync(IEntityFilter filter)
        {
            var filtered = await GetByAsync(filter);

            foreach (var e in filtered)
            {
                Console.WriteLine($"{e.Id} | {e.Name} | {e.Description} | Status: {e.Status}");
            }
        }
    }
}

