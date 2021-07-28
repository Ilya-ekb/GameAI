using BehaviourTree;
using Character.CharacterIndicator;

namespace Character.CharacterBehaviour
{
    public interface IAction
    {
        ICharacter thisCharacter { get; set; }
        IKnowlerge NeededKnowlegre { get; }
        ResultType Do(params object[] vs);
    }
}
