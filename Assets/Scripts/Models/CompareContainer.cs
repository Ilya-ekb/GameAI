using Models.CharacterModel;
using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CompareContainer<T> : VariableContainer<T> where T : BaseVariable
    {
        public CompareMode CompareMode => compareMode;
        [SerializeField] protected CompareMode compareMode;

        public CompareContainer(T variable, float value) : base(variable, value) { }
    }
}
