using System.Collections.Generic;
using Models.CharacterModel;
using UnityEngine;

namespace Models
{
    public abstract class Exchanger<T>
    {
        protected Exchanger(BaseVariableContainer sourceContainer, List<ExchangeContainer<BaseVariable>> recipientContainers)
        {
            this.sourceContainer = new VariableContainer<BaseVariable>(sourceContainer.Variable, sourceContainer.Value);
            this.recipientContainers = recipientContainers;
        }
        public VariableContainer<BaseVariable> SourceContainer => sourceContainer;
        public List<ExchangeContainer<BaseVariable>> RecipientContainers => recipientContainers;
        
        [SerializeField] protected VariableContainer<BaseVariable> sourceContainer;
        [SerializeField] protected List<ExchangeContainer<BaseVariable>> recipientContainers;

        public abstract void Exchange(T character);
    }
}
