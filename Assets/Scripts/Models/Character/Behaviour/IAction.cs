using BehaviourTree;
using Models.CharacterModel.Conditions.Knowlerge;
using Models.Resources;

using System;

namespace Models.CharacterModel.Behaviour
{
    public interface IAction
    {
        string Id { get; }
        ResultType Do(ICharacter character);
    }
}
