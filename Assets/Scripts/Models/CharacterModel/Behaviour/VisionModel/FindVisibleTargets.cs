using BehaviourTree.Core;

using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.Data;

using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [CreateAssetMenu(fileName = "Find Visible Target", menuName = "Character/Behaviour/Find Visible Target")]
    public class FindVisibleTargets : ActionEventObject
    {
        [SerializeField] private VisionData data;
        public override ResultType Do(ICharacter character)
        {
            var visionBehaviour = character.VisionBehaviour;
            if (!(visionBehaviour is RayVisionBehaviour)) 
            {
                visionBehaviour = new RayVisionBehaviour(visionBehaviour.LookingTransform, data);
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
