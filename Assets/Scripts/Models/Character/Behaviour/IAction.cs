using BehaviourTree;
using Models.CharacterModel.Conditions.Knowlerge;
using Models.Resources;

namespace Models.CharacterModel.Behaviour
{
    public interface IAction
    {
        ResultType Do(ICharacter character);
    }
}
