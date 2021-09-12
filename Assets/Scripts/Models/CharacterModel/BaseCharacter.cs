using BehaviourTree.Core;
using BehaviourTree.Data;
using BehaviourTree.Implementor;

using Models.CharacterModel.Behaviour.MoveModel;
using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.KnowledgeModel;
using Models.CharacterModel.SkillModel;
using Models.CharacterModel.Conditions;
using Models.Resources;

using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Models.CharacterModel
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter, IVariableSubject
    {
        public BaseVisionBehaviour VisionBehaviour { get; set; }
        public IEnumerable<BaseVariableContainer> BaseVariableContainer { get; private set; }

        public List<VariableContainer<GameResource>> Resources => resources;
        public List<VariableContainer<Knowledge>> Knowledge => knowledge;
        public List<VariableContainer<Condition>> Conditions => conditions;
        public List<VariableContainer<Skill>> Skills => skills; 
        public Transform Transform => transform;

        public Target Target { get; set; }

        [SerializeField] private NodeAsset behaviourModelData;

        [SerializeField] private List<VariableContainer<GameResource>> resources;
        [SerializeField] private List<VariableContainer<Knowledge>> knowledge;
        [SerializeField] private List<VariableContainer<Condition>> conditions;
        [SerializeField] private List<VariableContainer<Skill>> skills;

        private NodeRoot behaviour;

        protected virtual void Start()
        {
            BaseVariableContainer = AllVariableContainers();
            behaviour =  BehaviourImplementor.GetBehaviourNode(behaviourModelData.NodeData);
        }

        protected virtual void Update()
        {
            VisionBehaviour?.FindVisibleTargets();
            behaviour?.Execute(this);
        }

        public BaseVariableContainer FindContainer<T>(T variable) where T : BaseVariable
        {
            return BaseVariableContainer.FirstOrDefault(e=>e.Variable == variable);
        }

        private IEnumerable<BaseVariableContainer> AllVariableContainers()
        {
            var result = resources.Concat(conditions.Cast<BaseVariableContainer>());
            
            result = result.Concat(knowledge);

            return result;
        }
    }
}
