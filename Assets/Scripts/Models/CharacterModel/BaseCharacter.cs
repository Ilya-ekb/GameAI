using BehaviourTree.Core;
using BehaviourTree.Data;
using BehaviourTree.Implementor;

using Models.CharacterModel.Conditions;
using Models.CharacterModel.KnowledgeModel;
using Models.Resources;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Models.CharacterModel
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter
    {
        public List<VariableContainer<GameResource>> Resources => resources;
        public List<VariableContainer<Knowledge>> Knowledge => knowledge;

        public List<VariableContainer<Condition>> Conditions => conditions;
        public Transform Transform => transform;

        [SerializeField] private NodeAsset behaviourModelData;
        [SerializeField] private List<VariableContainer<GameResource>> resources;
        [SerializeField] private List<VariableContainer<Knowledge>> knowledge;
        [SerializeField] private List<VariableContainer<Condition>> conditions;

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
