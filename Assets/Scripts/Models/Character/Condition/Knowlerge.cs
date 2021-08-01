using Models.Resources;
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Character.Condition.Knowlerge
{
    [CreateAssetMenu(fileName = "Knowlerge", menuName ="Character/Condition/Knowlerge")]
    public class Knowlerge : Condition, IKnowlerge
    {
        public KnowlergeType KnowlergeType => knowlergeType;

        public IEnumerable<IResource> NeedResources => needResources ;

        public IEnumerable<ICondition> NeedConditions => needConditions;

        [SerializeField] private KnowlergeType knowlergeType;
        [SerializeField] private List<Resource> needResources;
        [SerializeField] private List<Condition> needConditions;

        public virtual bool CanUse(ICharacter character, Func<ICharacter, bool>[] conditionCompairs)
        {
            var characterKnowlerge = character.Knowlerges.Find(e => e.KnowlergeType == knowlergeType);
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
                var suitableResources = character.Resources.FindAll(e => e.ResourceType == resource.ResourceType);
                if(suitableResources != null)
                {
                    suitableResources = suitableResources.FindAll(e => e.Count >= resource.Count);
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
    }
     
}
