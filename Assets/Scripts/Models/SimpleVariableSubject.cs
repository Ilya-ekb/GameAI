using System;
using System.Collections.Generic;
using Models.CharacterModel;
using UnityEngine;
using BehaviourTree.Core;

namespace Models
{
    public class SimpleVariableSubject : MonoBehaviour, IVariableSubject
    {
        public Transform Transform => transform;
        public Dictionary<BaseVariable, BaseVariableContainer> BaseVariableContainer => baseVariableContainersDictionary;
        public IVariableSubject CurrentInteractable { get; set; }
        public Action EmptiedAction { get; set; }
        private readonly Dictionary<BaseVariable, BaseVariableContainer> baseVariableContainersDictionary = new Dictionary<BaseVariable, BaseVariableContainer>();

        [SerializeField] private VariableContainer<BaseVariable>[] baseVariableContainers;

        private void Start()
        {
            foreach (var baseVariableContainer in baseVariableContainers)
            {
               baseVariableContainersDictionary.Add(baseVariableContainer.Variable, baseVariableContainer); 
            }

            EmptiedAction += () => { gameObject.SetActive(false); };
        }

        public ResultType Interaction(IVariableSubject variableSubject)
        {
            if (variableSubject == null)
            {
                return ResultType.Fail;
            }

            variableSubject.CurrentInteractable = this;
            return ResultType.Success;
        }
    }
}
