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

            var visibleTarget = visionBehaviour.NearestTarget() ?? visionBehaviour.RandomTarget();

            character.Target = visibleTarget;
            Debug.Log($"Action {name} target {character.Target?.Name}");
            return ResultType.Success;
        }
    }
}
