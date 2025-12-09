using System.Collections.Generic;

namespace Task2_StructuralPatterns_Client
{
    public interface IEntityFilter
    {
        IEnumerable<SomeEntity> Apply(IEnumerable<SomeEntity> items);
    }
}

