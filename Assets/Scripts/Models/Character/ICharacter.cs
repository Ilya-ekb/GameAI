using Character.Behaviour;
using Character.Condition;
using Character.Condition.Knowlerge;
using Models.Resources;
using System.Collections.Generic;

namespace Character
{
    public interface ICharacter
    {
        List<ICondition> Conditions { get; }
        List<IResource> Resources{ get; }
        List<IKnowlerge> Knowlerges { get; }
        List<IAction> Actions { get; }
    }
}
