using Models.Resources;
using System.Collections.Generic;

namespace Models.CharacterModel.Conditions.Knowlerge
{
    public interface IKnowlerge : ICondition
    {
        KnowlergeType KnowlergeType { get; }
        IEnumerable<VariableContainer<GameResource>> NeedResources { get; }
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

