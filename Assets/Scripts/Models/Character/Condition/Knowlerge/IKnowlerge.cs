using Models.Resources;
using System.Collections.Generic;

namespace Character.Condition.Knowlerge
{
    public interface IKnowlerge : ICondition
    {
        KnowlergeType KnowlergeType { get; }
        IEnumerable<IResource> NeedResources { get; }
        IEnumerable<ICondition> NeedConditions { get; }

    }
    public enum KnowlergeType 
    {
        None,
        Treatment,
        Shooting,
        Cook,
    }

}

