using Models.Resources;
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Models.Character.Conditions.Knowlerge
{
    [CreateAssetMenu(fileName = "Knowlerge", menuName ="Character/Knowlerge")]
    public class Knowlerge : ScriptableObject, IKnowlerge
    {
        public KnowlergeType KnowlergeType => knowlergeType;

        public IEnumerable<VariableContainer<Resource>> NeedResources => needResources;

        public IEnumerable<VariableContainer<Condition>> NeedConditions => needConditions;

        public float MaxValue => maxValue;
        public float MinValue => minValue;

        public IEnumerable<ConditionAttribyte> ConditionAttributes => conditionAttribytes;

        private IEnumerable<ConditionAttribyte> conditionAttribytes = new ConditionAttribyte[] { ConditionAttribyte.Knowlerge }; 

        [SerializeField] private KnowlergeType knowlergeType;
        [SerializeField] private float maxValue;
        [SerializeField] private float minValue;

        [SerializeField] private List<VariableContainer<Resource>> needResources;
        [SerializeField] private List<VariableContainer<Condition>> needConditions;
        [SerializeField] private List<VariableContainer<Knowlerge>> needKnolerges;

        public virtual bool CanUse(ICharacter character, Func<ICharacter, bool>[] conditionCompairs)
        {
            var characterKnowlerge = character.Knowlerges.Find(e => e.Variable.KnowlergeType == knowlergeType);
            if (characterKnowlerge != null)
            {
                return EnoughResources(character) && EnoughConditions(character, conditionCompairs);  
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

        private bool EnoughConditions(ICharacter character, Func<ICharacter, bool>[] conditionCompairs)
        {
            foreach(var condition in conditionCompairs)
            {
                if (!condition(character))
                {
                    return false;   
                }
            }
            return true;
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
