using BehaviourTree.Core;
using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.Data;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [CreateAssetMenu(fileName = "Find Base Variable Target", menuName = "Character/Behaviour/Action Event Object/Find Base Variable Target")]
    public class FindBaseVariableTarget : ActionEventObject
    {
        [SerializeField] private VisionData data;

        public override ResultType Do(ICharacter character)
        {
            if (!(character.VisionBehaviour is BaseVariableVisionBehaviour visionBehaviour) )
            {
                visionBehaviour = new BaseVariableVisionBehaviour(character.VisionBehaviour.LookingTransform, data);
                character.VisionBehaviour = visionBehaviour;
            }
            else
            {
                visionBehaviour.UpdateData(data);
            }

            var result = ResultType.Fail;

            var visibleTarget = visionBehaviour.NearestTarget(ref result) ?? visionBehaviour.RandomTarget(ref result);

            character.Target = visibleTarget;

            return result;
        }
    }
}
