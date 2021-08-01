using BehaviourTree;
using Character.Condition.Knowlerge;
using Models.Resources;

namespace Character.Behaviour
{
    public interface IAction
    {
        IKnowlerge[] NeededKnowlerges { get; }
        IResource[] NeededResources { get; }
        ResultType Do(ICharacter character);
    }
}
