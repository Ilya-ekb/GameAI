using BehaviourTree.Core;
using Models.CharacterModel.KnowledgeModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    [System.Serializable, CreateAssetMenu(fileName = "Exchange Variable Action", menuName = "Character/Behaviour/Action Event Object/Exchange Variable Action")]
    public class ExchangeVariableAction : ActionEventObject
    {
        [SerializeField] protected Knowledge[] neededKnowledge;

        [SerializeField] private List<InternalExchanger> variablesExchangers;

        public override ResultType Do(ICharacter character)
        {
            ResultType result;

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
                result = ResultType.Success;
            }

            return result;
        }

        private bool CanDo(ICharacter character)
        {
            return neededKnowledge.All(knowledge => knowledge.CanUse(character));
        }
    }
}
