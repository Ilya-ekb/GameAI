using System.Collections.Generic;

namespace Models.Resources
{
    public interface IResource : IVariable
    {
        IEnumerable<ResourceAttribute> ResoureAttributes { get; }
    }

    public enum ResourceAttribute
    {
        None,
        Food,
        Medicines
    }
}
