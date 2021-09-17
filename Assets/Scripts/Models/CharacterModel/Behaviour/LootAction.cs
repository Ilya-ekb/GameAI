using BehaviourTree.Core;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [System.Serializable, CreateAssetMenu(fileName = "Loot Action", menuName = "Character/Behaviour/Action Event Object/Loot Action")]
    public class LootAction : ActionEventObject
    {
        public override ResultType Do(ICharacter character)
        {
            if (!(character is IVariableSubject variableSubject))
            {
                return ResultType.Fail;
            }

            return variableSubject.Interaction(variableSubject);
        }
    }
}
