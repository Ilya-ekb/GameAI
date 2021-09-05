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
                var recCharCont = character.FindContainer(recipientContainer.Variable);

                var sourceValue = Mathf.Min(source.Value, sourceContainer.Value);
                var recValue = recipientContainer.GetValue(sourceValue);

                source.Value = Mathf.Clamp(source.Value - sourceValue, source.Variable.MinValue, source.Variable.MaxValue);
                recCharCont.Value =  Mathf.Clamp(recCharCont.Value + recValue, recCharCont.Variable.MinValue, recCharCont.Variable.MaxValue);

                Debug.Log($"Exchange {source.Variable.name} value {sourceValue} on {recCharCont.Variable.name} value {recValue}");
            }
        }
    }
}
