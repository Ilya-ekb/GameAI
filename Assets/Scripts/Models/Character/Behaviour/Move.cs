using BehaviourTree;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [CreateAssetMenu(fileName = "Move Action", menuName = "Character/Behaviour/Move Action")]
    public class Move : ActionEventObject
    {
        public Vector3 TargetPosition { get => targetPosition; set => targetPosition = value; }
        public Quaternion TargetRotation { get => targetRotation; set => targetRotation = value; }

        private Vector3 targetPosition;
        private Quaternion targetRotation;
        private System.Action<float> moveAction;
        private float moveSpeed;

        public override ResultType Do(ICharacter character)
        {
            if ((character.Transform.position - targetPosition).magnitude > .1f && Quaternion.Angle(character.Transform.rotation, targetRotation) > 1f)
            {
                moveAction.Invoke(moveSpeed);
                return ResultType.Running;
            }
            return ResultType.Success;
        }
    }
}
