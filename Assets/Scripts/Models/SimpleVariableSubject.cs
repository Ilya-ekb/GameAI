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
        public IEnumerable<BaseVariableContainer> BaseVariableContainer => baseVariableContainers;
        public IVariableSubject CurrentInteractable { get; set; }
        public Action EmptiedAction { get; set; }

        [SerializeField] private VariableContainer<BaseVariable>[] baseVariableContainers;

        private void Start()
        {
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
