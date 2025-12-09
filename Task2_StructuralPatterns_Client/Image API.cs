using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task2_StructuralPatterns_Client
{
    public interface IImageApi
    {
        Task<string?> GetImageAsync(Guid id);
        Task SetImageAsync(Guid id, string url);

        Task<IEnumerable<SomeImageEntity>> GetEntitiesByFilterAsync(IEntityFilter filter);
    }
}
