using Models.CharacterModel.Conditions;
using Models.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel.KnowlergeModel
{
    [CreateAssetMenu(fileName = "Knowledge", menuName ="Character/Knowledge")]
    public class Knowledge : BaseVariable
    {
        private KnowledgeType KnowledgeType => knowledgeType;

        public override float MaxValue => maxChangeValue;
        public override float MinValue => minChangeValue;

        [SerializeField] private KnowledgeType knowledgeType;
        [SerializeField] private float maxChangeValue;
        [SerializeField] private float minChangeValue;

        [SerializeField] private List<CompairContainer<GameResource>> needResources;
        [SerializeField] private List<CompairContainer<Condition>> needConditions;
        [SerializeField] private List<CompairContainer<Knowledge>> needKnowledge;

        public virtual bool CanUse(ICharacter character)
        {
            var characterKnowledge = character.Knowledge.Find(e => (e.Variable as Knowledge).KnowledgeType == knowledgeType);
            if (characterKnowledge != null)
            {
                return Enough(character, needResources) && 
                       Enough(character, needKnowledge) && 
                       Enough(character, needConditions);  
            }
            return false;
        }

        private bool Enough<T>(ICharacter character, List<CompairContainer<T>> compareContainer)  where T : BaseVariable
        {
            var result = true;
            foreach(var comparable in compareContainer)
            {
                var characterCondition = character.FindContainer(comparable.Variable);
                if(characterCondition != null)
                {
                    if (!CompairAction<T>.Compairs[comparable.CompairMode].Invoke(characterCondition, comparable))
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
            needKnowledge.ForEach(e => e.Update($"{e.Variable?.name} {comp[e.CompairMode]} {e.Value}"));
        }
    }
     
}
