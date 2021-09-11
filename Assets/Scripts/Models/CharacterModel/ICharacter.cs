using Models.CharacterModel.Conditions;
using Models.CharacterModel.KnowledgeModel;
using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.SkillModel;
using Models.Resources;

using System.Collections.Generic;

using UnityEngine;

namespace Models.CharacterModel
{
    public interface ICharacter
    {
        Transform Transform { get; }
        List<VariableContainer<Condition>> Conditions { get; }
        List<VariableContainer<GameResource>> Resources{ get; }
        List<VariableContainer<Knowledge>> Knowledge { get; }
        List<VariableContainer<Skill>> Skills { get; }
        BaseVisionBehaviour VisionBehaviour { get; set; }

        Target Target { get; set; }

        BaseVariableContainer FindContainer<T>(T container) where T: BaseVariable;
    }
}
