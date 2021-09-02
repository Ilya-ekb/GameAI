using BehaviourTree.Core;
using BehaviourTree.Data;
using BehaviourTree.Realiser;

using Models.CharacterModel.Conditions;
using Models.CharacterModel.KnowlergeModel;
using Models.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter
    {
        public List<VariableContainer<GameResource>> Resources => resources;
        public List<VariableContainer<Knowlerge>> Knowlerges => knowlerges;
        public List<VariableContainer<Condition>> Conditions => conditions;
        public Transform Transform => transform;

        [SerializeField] private NodeAsset behaviourModelData;
        [SerializeField] private List<VariableContainer<GameResource>> resources;
        [SerializeField] private List<VariableContainer<Knowlerge>> knowlerges;
        [SerializeField] private List<VariableContainer<Condition>> conditions;

        private List<VariableContainer<BaseVariable>> commonContainers;
        private NodeRoot behaviour;

        protected virtual void Start()
        {
            commonContainers = new List<VariableContainer<BaseVariable>>();
            UpdateCommonContainers();
            behaviour =  BehaviourRealiser.GetBehaviourNode(behaviourModelData.NodeData);
        }

        protected virtual void Update()
        {
            behaviour?.Execute(this);
        }

        public VariableContainer<T> FindContainer<T>(T variable) where T : BaseVariable
        {
            Debug.Log($"Find {variable.name}");
            var result = commonContainers.Find(e => e.Variable == variable) as VariableContainer<T>;
            return result;
        }

        private void UpdateCommonContainers()
        {
            commonContainers = new List<VariableContainer<BaseVariable>>();
            commonContainers.AddRange(Cast(Resources));
            commonContainers.AddRange(Cast(Knowlerges));
            commonContainers.AddRange(Cast(Conditions));
        }

        private IEnumerable<VariableContainer<BaseVariable>> Cast<D>(IEnumerable<VariableContainer<D>> variableContainers)  where D : BaseVariable
        {
            List<VariableContainer<BaseVariable>> list = new List<VariableContainer<BaseVariable>>();
            foreach(var variableContainer in variableContainers)
            {
                list.Add(variableContainer as VariableContainer<BaseVariable>);
            }
            return list;
        }
    }
}
