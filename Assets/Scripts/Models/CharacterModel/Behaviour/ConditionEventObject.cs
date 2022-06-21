using BehaviourTree.Core;
using Models.CharacterModel;
using Models.CharacterModel.Behaviour;
using Models.CharacterModel.Conditions;
using UnityEngine;

namespace Models
{
    [System.Serializable, CreateAssetMenu(fileName = "Condition Event Object", menuName = "Character/Behaviour/Condition Event Object")]
    public class ConditionEventObject : BaseEventObject
    {
        [SerializeField] protected CompareContainer<BaseVariable>[] checkingConditions;

        public override ResultType Do(ICharacter character)
        {
            if(checkingConditions == null || checkingConditions.Length == 0)
            {
                return ResultType.Fail;
            }
            var resultType = ResultType.Success;
            foreach (var checkingCondition in checkingConditions)
            {
                var characterCondition = character.GetContainerWith(checkingCondition.Variable);
                if (characterCondition == null)
                {
                    resultType = ResultType.Fail;
                    break;
                }

                if (CompareAction<BaseVariable>.Compares[checkingCondition.CompareMode].Invoke(characterCondition, checkingCondition))
                {
                    continue;
                }
                resultType = ResultType.Fail;
                break;
            }
            return resultType;
        }
    }
}
