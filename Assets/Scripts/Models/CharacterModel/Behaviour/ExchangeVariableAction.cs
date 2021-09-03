using BehaviourTree.Core;
using Models.CharacterModel.KnowlergeModel;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [System.Serializable, CreateAssetMenu(fileName = "Exchange Variable Action", menuName = "Character/Behaviour/Action Event Object/Exchange Variable Action")]
    public class ExchangeVariableAction : ActionEventObject
    {
        [SerializeField] protected Knowlerge[] neededKnowlerges;

        [SerializeField] private List<VariableExchanger> variablesExchangers;

        public override ResultType Do(ICharacter character)
        {
            var result = ResultType.Fail;

            if (CanDo(character))
            {
                foreach(var exchanger in variablesExchangers)
                {
                    exchanger.Exchange(character);
                }
            }

            return result;
        }

        private bool CanDo(ICharacter character)
        {
            foreach (var knowlerge in neededKnowlerges)
            {
                if (!knowlerge.CanUse(character))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
