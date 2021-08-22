using BehaviourTree;

using Models;
using Models.CharacterModel;
using Models.CharacterModel.Behaviour;
using Models.CharacterModel.Conditions;
using Models.CharacterModel.Conditions.Knowlerge;

using UnityEngine;

[CreateAssetMenu(fileName = "Change Condition Action", menuName = "Character/Behaviour/Change Condition Action")]
public class ChangeConditionAction : Action
{

    [SerializeField] private Condition changingCondition;

    public override ResultType Do(ICharacter character)
    {
        var result = ResultType.Fail;

        if (CanDo(character, out VariableContainer<Condition> conditionContainer))
        {
            conditionContainer.Change(ComputeChangeValue(character, neededKnowlerges));
        }

        return result;
    }

    private bool CanDo(ICharacter character, out VariableContainer<Condition> conditionContainer)
    {
        foreach (var knowlerge in neededKnowlerges)
        {
            if (!knowlerge.CanUse(character))
            {
                conditionContainer = null;
                return false;
            }
        }

        conditionContainer = character.Conditions.Find(e => e.Variable == changingCondition);

        return conditionContainer != null;
    }

}
