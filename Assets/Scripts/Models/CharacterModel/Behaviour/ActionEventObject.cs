using Models.CharacterModel.KnowlergeModel;

using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    public abstract class ActionEventObject : BaseEventObject
    {
        protected float ComputeChangeValue(ICharacter character, Knowledge[] knowlerges)
        {
            float result = 0.0f;
            foreach (var knowledge in knowlerges)
            {
                var knowledgeContainer = character.FindContainer(knowledge);
                result += knowledgeContainer.Value;
            }

            Debug.Log($"Action {name} result {result}");
            return result;
        }
    }
}
