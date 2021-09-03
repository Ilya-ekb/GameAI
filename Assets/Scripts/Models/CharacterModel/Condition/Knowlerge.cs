using Models.CharacterModel.Conditions;
using Models.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel.KnowlergeModel
{
    [CreateAssetMenu(fileName = "Knowlerge", menuName ="Character/Knowlerge")]
    public class Knowlerge : BaseVariable
    {
        public KnowlergeType KnowlergeType => knowlergeType;

        public override float MaxValue => maxChangeValue;
        public override float MinValue => minChangeValue;

        [SerializeField] private KnowlergeType knowlergeType;
        [SerializeField] private float maxChangeValue;
        [SerializeField] private float minChangeValue;

        [SerializeField] private List<CompairContainer<GameResource>> needResources;
        [SerializeField] private List<CompairContainer<Condition>> needConditions;
        [SerializeField] private List<CompairContainer<Knowlerge>> needKnowlerges;

        public virtual bool CanUse(ICharacter character)
        {
            var characterKnowlerge = character.Knowlerges.Find(e => (e.Variable as Knowlerge).KnowlergeType == knowlergeType);
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
                var suitableResources = character.Resources.FindAll(e => (e.Variable as GameResource).ResoureAttributes == (resource.Variable as GameResource).ResoureAttributes);
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
            Dictionary<CompairMode, string> comp = new Dictionary<CompairMode, string> 
            { 
                { CompairMode.Equals, "==" }, 
                { CompairMode.NotEquals, "!=" }, 
                { CompairMode.Greater, ">" }, 
                { CompairMode.GreaterOrEquals, ">=" }, 
                { CompairMode.Less, "<" }, 
                { CompairMode.LessOrEquals, "<=" }, 
            };
            needConditions.ForEach(e => e.Update($"{e.Variable?.name} {comp[e.CompairMode]} {e.Value}"));
            needResources.ForEach(e => e.Update($"{e.Variable?.name} {comp[e.CompairMode]} {e.Value}"));
            needKnowlerges.ForEach(e => e.Update($"{e.Variable?.name} {comp[e.CompairMode]} {e.Value}"));
        }
    }
     
}
