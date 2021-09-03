using BehaviourTree.Core;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [CreateAssetMenu(fileName = "Move Action", menuName = "Character/Behaviour/Move Action")]
    public class Move : ActionEventObject
    {
        public override ResultType Do(ICharacter character)
        {
            var result = ResultType.Fail;
            if (character is MovableCharacter movableCharacter)
            {
                movableCharacter.Move();

                result = movableCharacter.IsReached ? ResultType.Success :
                    movableCharacter.Velocity.magnitude < .1f ? ResultType.Fail :
                    ResultType.Running;
            }

            Debug.Log($"{name} action {result}");

            return result;
        }
    }
}
