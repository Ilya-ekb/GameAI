using BehaviourTree;
using Models.CharacterModel.Conditions;
using Models.CharacterModel.Conditions.Knowlerge;

using System.Collections.Generic;

using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [System.Serializable, CreateAssetMenu(fileName = "Change Variable Action", menuName = "Character/Behaviour/Action Event Object/Change Variable Action")]
    public class ChangeVariableAction : ActionEventObject
    {
        [SerializeField] protected Knowlerge[] neededKnowlerges;

        [SerializeField] private BaseVariable[] changingVariables;

        public override ResultType Do(ICharacter character)
        {
            var result = ResultType.Fail;

            if (CanDo(character, out List<VariableContainer<BaseVariable>> variableContainers))
            {
                foreach(var variableContainer in variableContainers)
                {
                    variableContainer.Change(ComputeChangeValue(character, neededKnowlerges));
                }
            }

            return result;
        }

        private bool CanDo(ICharacter character, out List<VariableContainer<BaseVariable>> variableContainers)
        {
            variableContainers = new List<VariableContainer<BaseVariable>>();
            foreach (var knowlerge in neededKnowlerges)
            {
                if (!knowlerge.CanUse(character))
                {
                    variableContainers = null;
                    return false;
                }
            }

            foreach ( var changingVar in changingVariables)
            {
                variableContainers.Add(character.FindContainer(changingVar));
            }

            return variableContainers.Count == changingVariables.Length;
        }
    }
}
