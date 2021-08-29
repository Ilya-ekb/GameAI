using Models.CharacterModel.Conditions;

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CompairContainer<T> : VariableContainer<T> where T : BaseVariable
    {
        public CompairMode CompairMode => compairMode;
        [SerializeField] protected CompairMode compairMode;
    }
}
