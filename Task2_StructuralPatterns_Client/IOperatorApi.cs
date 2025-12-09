using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task2_StructuralPatterns_Client
{
    public interface IOperatorApi
    {
        Task<IEnumerable<SomeEntity>> GetManyAsync();
        Task<SomeEntity> CreateAsync(SomeEntity entity);
        Task<SomeEntity?> GetOneAsync(Guid id);
    }
    
    }

