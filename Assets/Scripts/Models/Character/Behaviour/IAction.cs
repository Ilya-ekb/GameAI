using BehaviourTree;

namespace Models.CharacterModel.Behaviour
{
    public interface IAction
    {
        string Id { get; }
        ResultType Do(ICharacter character);
    }
}
