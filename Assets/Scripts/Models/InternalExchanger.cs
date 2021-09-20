using UnityEngine;
using System;
using System.Collections.Generic;
using Models.CharacterModel;

namespace Models
{
    [Serializable]
    public class InternalExchanger : Exchanger<ICharacter>
    {
        public override void Exchange(ICharacter character)
        {
            var source = character.GetContainerWith(sourceContainer.Variable);
            var sourceValue = Mathf.Min(source.Value, sourceContainer.Value);

            foreach (var recipientContainer in recipientContainers)
            {
                var recCharCont = character.GetContainerWith(recipientContainer.Variable);

                var recValue = recipientContainer.GetValue(sourceValue);
                
                recCharCont.Value =  Mathf.Clamp(recCharCont.Value + recValue, recCharCont.Variable.MinValue, recCharCont.Variable.MaxValue);
            }
            source.Value = Mathf.Clamp(source.Value - sourceValue, source.Variable.MinValue, source.Variable.MaxValue);
        }

        public InternalExchanger(VariableContainer<BaseVariable> sourceContainer, List<ExchangeContainer<BaseVariable>> recipientContainers) : base(sourceContainer, recipientContainers) { }
    }
}
