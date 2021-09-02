using Models.CharacterModel.Conditions;
using UnityEngine;
using System;
using System.Collections.Generic;
using Models.CharacterModel;

namespace Models
{
    [Serializable]
    public class VariableExchanger
    {
        public VariableContainer<BaseVariable> SourceContainer => sourceContainer;
        [SerializeField] private VariableContainer<BaseVariable> sourceContainer;
        public List<ExchangeContainer<BaseVariable>> RecipientContainers => recipientContainers;
        [SerializeField] private List<ExchangeContainer<BaseVariable>> recipientContainers;

        public void Exchange(ICharacter character)
        {
            var source = character.FindContainer(sourceContainer.Variable);
            foreach (var recipientContainer in recipientContainers)
            {
                var sourceValue = Mathf.Min(source.Value, sourceContainer.Value);
                character.FindContainer(recipientContainer.Variable).Value += recipientContainer.GetValue(sourceValue);
            }
        }
    }
}
