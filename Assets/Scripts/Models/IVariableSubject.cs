using System;
using System.Collections.Generic;
using BehaviourTree.Core;
using UnityEngine;

namespace Models
{
    public interface IVariableSubject 
    {
        Transform Transform { get; }
        IEnumerable<BaseVariableContainer> BaseVariableContainer { get; }
        IVariableSubject CurrentInteractable { get; set; }
        ResultType Interaction(IVariableSubject character = null);
        public Action EmptiedAction { get; set; }
    }
}
