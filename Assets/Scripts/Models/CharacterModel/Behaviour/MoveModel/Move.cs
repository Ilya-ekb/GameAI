using BehaviourTree.Core;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.MoveModel
{
    [CreateAssetMenu(fileName = "Move Action", menuName = "Character/Behaviour/Action Event Object/Move Action")]
    public class Move : ActionEventObject
    {
        public override ResultType Do(ICharacter character)
        {
            var result = ResultType.Fail;
            if (character is MovableCharacter movableCharacter && character.Target != null)
            {
                movableCharacter.SetTarget(character.Target.Position);

                movableCharacter.Move();

                result = movableCharacter.IsReached ? ResultType.Success : ResultType.Running;
            }
            return result;
        }
    }
}
