using BehaviourTree.Core;
using Models.CharacterModel.KnowledgeModel;
using System.Collections.Generic;
using System.Linq;
using Models.Resources;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [System.Serializable, CreateAssetMenu(fileName = "Exchange Variable Action", menuName = "Character/Behaviour/Action Event Object/Exchange Variable Action")]
    public class ExchangeVariableAction : ActionEventObject
    {
        [SerializeField] protected Knowledge[] neededKnowledge;

        [SerializeField] private List<VariableExchanger> variablesExchangers;

        public override ResultType Do(ICharacter character)
        {
            var result = ResultType.Fail;

            if (CanDo(character))
            {
                foreach (var exchanger in variablesExchangers)
                {
                    exchanger.Exchange(character);
                }

                result = ResultType.Running;
            }
            else
            {
                Debug.Log($"{character} can't do {name}");
            }

            return result;
        }

        private bool CanDo(ICharacter character)
        {
            return neededKnowledge.All(knowledge => knowledge.CanUse(character));
        }
    }
}
