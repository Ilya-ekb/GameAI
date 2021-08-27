using Models.Resources;
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Models.CharacterModel.Conditions.Knowlerge
{
    [CreateAssetMenu(fileName = "Knowlerge", menuName ="Character/Knowlerge")]
    public class Knowlerge : BaseVariable
    {
        public KnowlergeType KnowlergeType => knowlergeType;

        public IEnumerable<VariableContainer<GameResource>> NeedResources => needResources;

        public IEnumerable<VariableContainer<Condition>> NeedConditions => needConditions;

        public override float MaxValue => maxChangeValue;
        public override float MinValue => minChangeValue;

        public IEnumerable<ConditionAttribyte> ConditionAttributes => conditionAttribytes;

        private IEnumerable<ConditionAttribyte> conditionAttribytes = new ConditionAttribyte[] { ConditionAttribyte.Knowlerge }; 

        [SerializeField] private KnowlergeType knowlergeType;
        [SerializeField] private float maxChangeValue;
        [SerializeField] private float minChangeValue;

        [SerializeField] private List<VariableContainer<GameResource>> needResources;
        [SerializeField] private List<VariableContainer<Condition>> needConditions;
        [SerializeField] private List<VariableContainer<Knowlerge>> needKnolerges;

        public virtual bool CanUse(ICharacter character)
        {
            var characterKnowlerge = character.Knowlerges.Find(e => e.Variable.KnowlergeType == knowlergeType);
            if (characterKnowlerge != null)
            {
                return EnoughResources(character) && EnoughConditions(character);  
            }
            return false;
        }

        private bool EnoughResources(ICharacter character)
        {
            foreach(var resource in needResources)
            {
                var suitableResources = character.Resources.FindAll(e => e.Variable.ResoureAttributes == resource.Variable.ResoureAttributes);
                if(suitableResources != null)
                {
                    suitableResources = suitableResources.FindAll(e => e.Value >= resource.Value);
                    if(suitableResources == null && suitableResources.Count > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool EnoughConditions(ICharacter character)
        {
            var result = false;
            foreach(var condition in needConditions)
            {
                var characterCondition = character.FindContainer(condition.Variable);
                if(characterCondition != null)
                {
                    result = CompairAction<Condition>.Compairs[condition.CompairMode].Invoke(characterCondition, condition);

                    if (!result)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        private void OnValidate()
        {
            foreach (var condition in needConditions)
            {
                condition.Update(condition.Variable?.ConditionAttributes.ToString());
            }
            foreach (var resource in needResources)
            {
                resource.Update(resource.Variable?.ResoureAttributes.ToString());
            }
        }
    }
     
}
