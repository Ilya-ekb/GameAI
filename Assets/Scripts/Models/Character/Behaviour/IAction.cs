using BehaviourTree;
using Models.Character.Conditions.Knowlerge;
using Models.Resources;

namespace Models.Character.Behaviour
{
    public interface IAction
    {
        IKnowlerge[] NeededKnowlerges { get; }
        ResultType Do(ICharacter character);
    }
}
