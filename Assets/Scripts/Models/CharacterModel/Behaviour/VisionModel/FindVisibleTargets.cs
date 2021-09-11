using BehaviourTree.Core;

using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.Data;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [CreateAssetMenu(fileName = "Find Visible Target", menuName = "Character/Behaviour/Find Visible Target")]
    public class FindVisibleTargets : ActionEventObject
    {
        [SerializeField] private VisionData data;
        public override ResultType Do(ICharacter character)
        {
            if (!(character.VisionBehaviour is RayVisionBehaviour)) 
            {
                character.VisionBehaviour = new RayVisionBehaviour(character.VisionBehaviour.LookingTransform, data);
            }
            else
            {
                character.VisionBehaviour.UpdateData(data);
            }

            var visibleTarget = character.VisionBehaviour.NearestTarget();
            if(visibleTarget == null)
            {
                return ResultType.Fail;
            }

            character.Target = visibleTarget;
            return ResultType.Success;
        }
    }
}
