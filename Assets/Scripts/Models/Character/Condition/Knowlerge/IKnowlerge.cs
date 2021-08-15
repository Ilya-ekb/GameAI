using Models.Resources;
using System.Collections.Generic;

namespace Models.Character.Conditions.Knowlerge
{
    public interface IKnowlerge : ICondition
    {
        KnowlergeType KnowlergeType { get; }
        IEnumerable<VariableContainer<Resource>> NeedResources { get; }
        IEnumerable<VariableContainer<Condition>> NeedConditions { get; }

    }
    public enum KnowlergeType 
    {
        None,
        Treatment,
        Shooting,
        Cook,
    }

}

