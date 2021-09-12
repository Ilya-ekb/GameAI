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
            var visionBehaviour = character.VisionBehaviour;

            if (visionBehaviour is BaseVariableVisionBehaviour)
            {
                visionBehaviour = new BaseVariableVisionBehaviour(visionBehaviour.LookingTransform, data);
            }
            else
            {
                visionBehaviour.UpdateData(data);
            }

            var visibleTarget = visionBehaviour.NearestTarget() ?? visionBehaviour.RandomTarget();

            character.Target = visibleTarget;
            return ResultType.Success;
        }
    }
}
