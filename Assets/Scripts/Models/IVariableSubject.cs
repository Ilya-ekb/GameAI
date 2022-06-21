using System;
using System.Collections.Generic;
using BehaviourTree.Core;
using Models.CharacterModel;
using UnityEngine;

namespace Models
{
    public interface IVariableSubject
    {
        Transform Transform { get; }
        Dictionary<BaseVariable, BaseVariableContainer> BaseVariableContainer { get; }
        IVariableSubject CurrentInteractable { get; set; }
        ResultType Interaction(IVariableSubject character = null);
        public Action EmptiedAction { get; set; }
    }
}
