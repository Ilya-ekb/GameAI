using Models.CharacterModel.Conditions;
using Models.Resources;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Models.CharacterModel.KnowledgeModel
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

        [SerializeField] private List<CompareContainer<GameResource>> needResources;
        [SerializeField] private List<CompareContainer<Condition>> needConditions;
        [SerializeField] private List<CompareContainer<Knowledge>> needKnowledge;

        public virtual bool CanUse(ICharacter character)
        {
            var characterKnowledge = character.Knowledge.Find(e => ((Knowledge) e.Variable).KnowledgeType == knowledgeType);
            if (characterKnowledge != null)
            {
                return Enough(character, needResources) && 
                       Enough(character, needKnowledge) && 
                       Enough(character, needConditions);  
            }
            return false;
        }

        private static bool Enough<T>(ICharacter character, IEnumerable<CompareContainer<T>> compareContainer)  where T : BaseVariable
        {
            return !(from comparable in compareContainer let characterCondition = character.FindContainer(comparable.Variable) where characterCondition != null where !CompareAction<T>.Compares[comparable.CompareMode].Invoke(characterCondition, comparable) select comparable).Any();
        }

        private void OnValidate()
        {
            var comp = new Dictionary<CompareMode, string> 
            { 
                { CompareMode.Equals, "==" }, 
                { CompareMode.NotEquals, "!=" }, 
                { CompareMode.Greater, ">" }, 
                { CompareMode.GreaterOrEquals, ">=" }, 
                { CompareMode.Less, "<" }, 
                { CompareMode.LessOrEquals, "<=" }, 
            };
            needConditions.ForEach(e => e.Update($"{e.Variable?.name} {comp[e.CompareMode]} {e.Value}"));
            needResources.ForEach(e => e.Update($"{e.Variable?.name} {comp[e.CompareMode]} {e.Value}"));
            needKnowledge.ForEach(e => e.Update($"{e.Variable?.name} {comp[e.CompareMode]} {e.Value}"));
        }
    }
     
}
