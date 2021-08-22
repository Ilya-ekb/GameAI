using UnityEngine;
using BehaviourTree;
using Models.CharacterModel.Conditions.Knowlerge;

namespace Models.CharacterModel.Behaviour
{
    public abstract class Action : ScriptableObject, IAction
    {
        [SerializeField] protected Knowlerge[] neededKnowlerges;

        public abstract ResultType Do(ICharacter character);
        
        protected float ComputeChangeValue(ICharacter character, IKnowlerge[] knowlerges)
        {
            float result = 0.0f;
            foreach (var knowlerge in knowlerges)
            {
                var knowlergeContainer = character.FindContainer(knowlerge);
                result += knowlergeContainer.Value;
            }

            return result;
        }
    }
}
