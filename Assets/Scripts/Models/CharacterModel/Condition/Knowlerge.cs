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
                return Enough(character, needResources) && 
                       Enough(character, needKnowlerges) && 
                       Enough(character, needConditions);  
            }
            return false;
        }

        private bool Enough<T>(ICharacter character, List<CompairContainer<T>> compairContainer)  where T : BaseVariable
        {
            var result = true;
            foreach(var compairable in compairContainer)
            {
                var characterCondition = character.FindContainer(compairable.Variable);
                if(characterCondition != null)
                {
                    if (!CompairAction<T>.Compairs[compairable.CompairMode].Invoke(characterCondition, compairable))
                    {
                        return false;
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
