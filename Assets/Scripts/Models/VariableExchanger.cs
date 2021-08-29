using Models.CharacterModel.Conditions;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class VariableExchanger
    {
        [SerializeField] private VariableContainer<BaseVariable> sourceContainer;
        public List<ExchangeContainer<BaseVariable>> RecipientContainers => recipientContainers;
        [SerializeField] private List<ExchangeContainer<BaseVariable>> recipientContainers;

        public void Exchange(float sourceValue)
        {
            sourceValue /= recipientContainers.Count;
            foreach (var recipientContainer in recipientContainers)
            {
                recipientContainer.GetValue(sourceValue);
            }
        }
    }
}
