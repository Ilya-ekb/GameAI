using BehaviourTree.Core;

namespace Models.CharacterModel.Behaviour
{
    public interface IAction
    {
        string Id { get; }
        string Name { get; }
        ResultType Do(ICharacter character);
    }
}
