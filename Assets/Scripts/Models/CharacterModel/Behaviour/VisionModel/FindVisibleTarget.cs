using BehaviourTree.Core;

using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.Data;

using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [CreateAssetMenu(fileName = "Find Visible Target", menuName = "Character/Behaviour/Action Event Object/Find Visible Target")]
    public class FindVisibleTarget : ActionEventObject
    {
        [SerializeField] private VisionData data;
        public override ResultType Do(ICharacter character)
        {
            var visionBehaviour = character.VisionBehaviour;

            if (!(visionBehaviour.GetType() == typeof(RayVisionBehaviour))) 
            {
                visionBehaviour = new RayVisionBehaviour(visionBehaviour.LookingTransform, data);
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
