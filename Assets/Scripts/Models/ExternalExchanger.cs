using System.Collections.Generic;
using System.Linq;
using Models.CharacterModel;
using UnityEngine;

namespace Models
{
    [System.Serializable]
    public class ExternalExchanger : Exchanger<IVariableSubject>
    {
        public ExternalExchanger(BaseVariableContainer sourceContainer,
            List<ExchangeContainer<BaseVariable>> recipientContainers) : base(sourceContainer, recipientContainers)
        {
        }

        public override void Exchange(IVariableSubject variableSubject)
        {
            var sourceInteractableSubject = variableSubject.CurrentInteractable;
            var sourceInteractableContainer = sourceInteractableSubject?.BaseVariableContainer.FirstOrDefault(e =>
                e.Variable == this.sourceContainer.Variable);

            if (!(variableSubject is ICharacter character) || sourceInteractableContainer == null)
            {
                return;
            }

            var sourceValue = Mathf.Min(sourceContainer.Value, sourceInteractableContainer.Value);

            foreach (var recipientContainer in recipientContainers)
            {
                var characterRecipientContainer = character.FindContainer(recipientContainer.Variable);

                var recValue = recipientContainer.GetValue(sourceValue);
                
                characterRecipientContainer.Value = Mathf.Clamp(characterRecipientContainer.Value + recValue, characterRecipientContainer.Variable.MinValue, characterRecipientContainer.Variable.MaxValue);
            }

            sourceInteractableContainer.Value = Mathf.Clamp(sourceInteractableContainer.Value - sourceValue, sourceInteractableContainer.Variable.MinValue, sourceInteractableContainer.Variable.MaxValue);
        }
    }
}
