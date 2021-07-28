using BehaviourTree;

using Character.CharacterBehaviour;
using UnityEngine;

[CreateAssetMenu(fileName = "TreatmentAction", menuName = "Character/Character Behaviour/Treatment Action")]
public class Treatment : Action
{
    public override ResultType Do(params object[] vs)
    {
        var result = ResultType.Fail;

        if (thisCharacter.Knowlerges.Contains(NeededKnowlegre) &&
            thisCharacter.Resources.Contains(thisCharacter.Health.RestoringResource))
        {
            if (!thisCharacter.Health.Full)
            {
                if(thisCharacter.Resources.Find(e => e.ResourceType == thisCharacter.Health.RestoringResource.ResourceType).Count > .0f)
                {
                    thisCharacter.Health.Increase(thisCharacter.Knowlerges.Find(e => e.KnowlergeType == NeededKnowlegre.KnowlergeType).Value);
                    result = ResultType.Running;
                }
            }
            else
            {
                result = ResultType.Success;
            }
        }
        return result;
    }
}
