using System;
using BehaviourTree.Core;
using BehaviourTree.Data;
using BehaviourTree.Implementor;

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
        public  Dictionary<BaseVariable,BaseVariableContainer> BaseVariableContainer { get; set; }
        public IVariableSubject CurrentInteractable { get; set; }
        public List<VariableContainer<GameResource>> Resources => resources;
        public List<VariableContainer<Knowledge>> Knowledge => knowledge;
        public List<VariableContainer<Condition>> Conditions => conditions;
        public List<VariableContainer<Skill>> Skills => skills;
        public List<ExternalExchanger> ExternalExchangers => externalExchangers ??= new List<ExternalExchanger>();

        public Transform Transform => transform;
        public Target Target { get; set; }

        [SerializeField] private NodeAsset behaviourModelData;

        [SerializeField] private List<VariableContainer<GameResource>> resources;
        [SerializeField] private List<VariableContainer<Knowledge>> knowledge;
        [SerializeField] private List<VariableContainer<Condition>> conditions;
        [SerializeField] private List<VariableContainer<Skill>> skills;
        [SerializeField] private List<ExternalExchanger> externalExchangers;

        private NodeRoot behaviour;

        protected virtual void Start()
        {
            BaseVariableContainer = AllVariableContainers();
            behaviour = BehaviourImplementor.GetBehaviourNode(behaviourModelData?.NodeData);
        }

        protected virtual void Update()
        {
            VisionBehaviour?.FindVisibleTargets();
            behaviour?.Execute(this);
        }

        public ResultType Interaction(IVariableSubject variableSubject = null)
        {
            var result = ResultType.Fail;

            if (CurrentInteractable != null && !CurrentInteractable.Transform.gameObject.activeSelf)
            {
                CurrentInteractable = null;
                return result;
            }

            if (CurrentInteractable == null)
            {
                return result;
            }

            var exchangers =
                externalExchangers.FindAll(e => BaseVariableContainer.ContainsKey(e.SourceContainer.Variable));

            if (exchangers.Count == 0)
            {
                return ResultType.Fail;
            }

            foreach (var exchanger in exchangers)
            {
                exchanger.Exchange(this);
                result = ResultType.Running;
            }

            if (!CurrentInteractable.BaseVariableContainer.All(e => e.Value.Value <= 0))
            {
                return result;
            }

            result = ResultType.Success;
            CurrentInteractable.EmptiedAction?.Invoke();

            return result;
        }

        public Action EmptiedAction { get; set; }

        public BaseVariableContainer GetContainerWith<T>(T variable) where T : BaseVariable
        {
            return BaseVariableContainer[variable];
        }

        private Dictionary<BaseVariable, BaseVariableContainer> AllVariableContainers()
        {
            var allContainers= resources.Concat(conditions.Cast<BaseVariableContainer>());

            allContainers = allContainers.Concat(knowledge);

            return allContainers.ToDictionary(baseVariableContainer => baseVariableContainer.Variable);
        }
    }
}
