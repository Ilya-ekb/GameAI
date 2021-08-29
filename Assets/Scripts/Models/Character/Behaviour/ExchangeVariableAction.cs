using BehaviourTree;
using Models.CharacterModel.Conditions;
using Models.CharacterModel.KnowlergeModel;

using System.Collections.Generic;

using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [System.Serializable, CreateAssetMenu(fileName = "Change Variable Action", menuName = "Character/Behaviour/Action Event Object/Change Variable Action")]
    public class ExchangeVariableAction : ActionEventObject
    {
        [SerializeField] protected Knowlerge[] neededKnowlerges;

        [SerializeField] private List<VariableExchanger> variablesExchangers;

        public override ResultType Do(ICharacter character)
        {
            var result = ResultType.Fail;

            if (CanDo(character, out List<VariableContainer<BaseVariable>> variableContainers))
            {
                foreach(var variableContainer in variableContainers)
                {
                    //variableContainer.Exchange(changingVariables.Find(e=>e.Variable == variableContainer.Variable));
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

            //foreach (var changingVar in variablesExchangers)
            //{
            //    variableContainers.Add(character.FindContainer(changingVar.Variable));
            //}

            return variableContainers.Count == variablesExchangers.Count;
        }
    }
}
