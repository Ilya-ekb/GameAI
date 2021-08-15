using Models.Character.Behaviour;
using Models.Character.Conditions;
using Models.Character.Conditions.Knowlerge;
using Models.Resources;
using System.Collections.Generic;

namespace Models.Character
{
    public interface ICharacter
    {
        List<VariableContainer<Condition>> Conditions { get; }
        List<VariableContainer<Resource>> Resources{ get; }
        List<VariableContainer<Knowlerge>> Knowlerges { get; }
        List<IAction> Actions { get; }
    }
}
