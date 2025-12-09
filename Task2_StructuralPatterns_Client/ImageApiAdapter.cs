using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_StructuralPatterns_Client
{
    public class ImageApiAdapter : IImageApi
    {
        private readonly IOperatorApi _operatorApi;
        private readonly Dictionary<Guid, string> _images = new();

        public ImageApiAdapter(IOperatorApi operatorApi)
        {
            _operatorApi = operatorApi;
        }

        public Task<string?> GetImageAsync(Guid id)
        {
            return Task.FromResult(
                _images.TryGetValue(id, out var url) ? url : null
            );
        }

        public async Task SetImageAsync(Guid id, string url)
        {
            var entity = await _operatorApi.GetOneAsync(id);
            if (entity == null)
            {
                Console.WriteLine($"[ImageApi] Entity {id} not found, we are not posting the picture");
                return;
            }

            _images[id] = url;
        }

        public async Task<IEnumerable<SomeImageEntity>> GetEntitiesByFilterAsync(IEntityFilter filter)
        {
            var all = await _operatorApi.GetManyAsync();
            var filtered = filter.Apply(all);

            var result = filtered.Select(e =>
            {
                _images.TryGetValue(e.Id, out var url);

                return new SomeImageEntity
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Status = e.Status,
                    ImageUrl = url
                };
            });

            return result.ToList();
        }
    }
}
