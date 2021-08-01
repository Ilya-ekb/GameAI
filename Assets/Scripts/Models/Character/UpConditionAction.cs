using BehaviourTree;
using Character;
using Character.Behaviour;

using System;

using UnityEngine;

[CreateAssetMenu(fileName = "Up Condition Action", menuName = "Character/Behaviour/Up Condition Action")]
public class UpConditionAction : Character.Behaviour.Action
{
    public override ResultType Do(ICharacter character)
    {
        var result = ResultType.Fail;


        return result;
    }

    private bool CanDo(ICharacter character, Func<ICharacter, bool>[] conditionCompairs)
    {
        foreach (var knowlerge in neededKnowlerges)
        {
            if (!knowlerge.CanUse(character, conditionCompairs))
            {
                return false;
            }
        }
        return true;
    }

}
