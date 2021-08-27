using Models.CharacterModel.Behaviour;
using Models.CharacterModel.Conditions;
using Models.CharacterModel.Conditions.Knowlerge;
using Models.Resources;
using System.Collections.Generic;

using UnityEngine;

namespace Models.CharacterModel
{
    public interface ICharacter
    {
        Transform Transform { get; }
        List<VariableContainer<Condition>> Conditions { get; }
        List<VariableContainer<GameResource>> Resources{ get; }
        List<VariableContainer<Knowlerge>> Knowlerges { get; }

        VariableContainer<T> FindContainer<T>(T container) where T: BaseVariable;
    }
}
