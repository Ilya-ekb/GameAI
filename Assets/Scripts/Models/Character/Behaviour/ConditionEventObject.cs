using BehaviourTree;
using Models.CharacterModel;
using Models.CharacterModel.Behaviour;
using Models.CharacterModel.Conditions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [System.Serializable, CreateAssetMenu(fileName = "Condition Event Object", menuName = "Character/Behaviour/Condition Event Object")]
    public class ConditionEventObject : BaseEventObject
    {
        [SerializeField] protected VariableContainer<BaseVariable>[] checkingCondtions;

        public override ResultType Do(ICharacter character)
        {
            ResultType resultType = ResultType.Success;
            foreach (var checkingCondition in checkingCondtions)
            {
                var characterCondition = character.FindContainer(checkingCondition.Variable);
                if (characterCondition == null)
                {
                    resultType = ResultType.Fail;
                    break;
                }

                if (!CompairAction<BaseVariable>.Compairs[checkingCondition.CompairMode].Invoke(characterCondition, checkingCondition))
                {
                    resultType = ResultType.Fail;
                    break;
                }
            }
            return resultType;
        }
    }
}
