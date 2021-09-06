using System.Collections.Generic;

namespace Models.Resources
{
    public interface IResource : IVariable
    {
        IEnumerable<ResourceAttribute> ResourceAttributes { get; }
    }

    public enum ResourceAttribute
    {
        None,
        Food,
        Medicines
    }
}
