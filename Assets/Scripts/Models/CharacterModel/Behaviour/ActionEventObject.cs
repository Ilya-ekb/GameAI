using System.Linq;
using Models.CharacterModel.KnowledgeModel;

using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    public abstract class ActionEventObject : BaseEventObject
    {
        protected float ComputeChangeValue(ICharacter character, Knowledge[] knowledgeArray)
        {
            var result = knowledgeArray.Select(character.FindContainer).Select(knowledgeContainer => knowledgeContainer.Value).Sum();

            Debug.Log($"Action {name} result {result}");
            return result;
        }
    }
}
