using BehaviourTree.Core;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [System.Serializable, CreateAssetMenu(fileName = "Loot Action", menuName = "Character/Behaviour/Action Event Object/Loot Action")]
    public class LootAction : ActionEventObject
    {
        public override ResultType Do(ICharacter character)
        {
            var result = ResultType.Fail;
            if (character is IVariableSubject variableSubject)
            {
                result = variableSubject.Interaction(variableSubject);
            }
            return result;
        }
    }
}
