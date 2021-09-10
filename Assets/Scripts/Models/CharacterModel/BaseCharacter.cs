using BehaviourTree.Core;
using BehaviourTree.Data;
using BehaviourTree.Implementor;

using Models.CharacterModel.Behaviour.MoveModel;
using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.KnowledgeModel;
using Models.CharacterModel.SkillModel;
using Models.CharacterModel.Conditions;
using Models.Resources;
using Models.CharacterModel.Data;

using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Models.CharacterModel
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter
    {
        public BaseVisionBehaviour VisionBehaviour
        {
            get;
            protected set;
        }

        public List<VariableContainer<GameResource>> Resources => resources;
        public List<VariableContainer<Knowledge>> Knowledge => knowledge;
        public List<VariableContainer<Condition>> Conditions => conditions;
        public List<VariableContainer<Skill>> Skills => skills; 
        public Transform Transform => transform;

        [SerializeField] private NodeAsset behaviourModelData;
        [SerializeField] protected VisionData visionData;

        [SerializeField] private List<VariableContainer<GameResource>> resources;
        [SerializeField] private List<VariableContainer<Knowledge>> knowledge;
        [SerializeField] private List<VariableContainer<Condition>> conditions;
        [SerializeField] private List<VariableContainer<Skill>> skills;

        private IEnumerable<BaseVariableContainer> commonContainers;
        private NodeRoot behaviour;

        protected virtual void Start()
        {
            commonContainers = AllVariableContainers();
            behaviour =  BehaviourImplementor.GetBehaviourNode(behaviourModelData.NodeData);
        }

        protected virtual void Update()
        {
            behaviour?.Execute(this);
        }

        public BaseVariableContainer FindContainer<T>(T variable) where T : BaseVariable
        {
            return commonContainers.FirstOrDefault(e=>e.Variable == variable);
        }

        private IEnumerable<BaseVariableContainer> AllVariableContainers()
        {
            var result = resources.Concat(conditions.Cast<BaseVariableContainer>());
            
            result = result.Concat(knowledge);

            return result;
        }
    }
}
