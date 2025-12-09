using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task2_StructuralPatterns_Client
{
    public class CrudApiClient
    {
        private readonly IOperatorApi _api;

        public CrudApiClient(IOperatorApi api)
        {
            _api = api;
        }
        public async Task<SomeEntity> CreateAsync(string name, string description, int status = 1)
        {
            var entity = new SomeEntity
            {
                Name = name,
                Description = description,
                Status = status
            };

            return await _api.CreateAsync(entity);
        }

        public async Task<IEnumerable<SomeEntity>> GetManyAsync()
        {
            return await _api.GetManyAsync();
        }

        public async Task PrintManyAsync()
        {
            var entities = await _api.GetManyAsync();

            foreach (var e in entities)
            {
                Console.WriteLine($"{e.Id} | {e.Name} | {e.Description} | Status: {e.Status}");
            }
        }
    }
}

