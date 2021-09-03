using Models.CharacterModel.Conditions;

using System;

using UnityEngine;

namespace Models
{
    [Serializable]
    public class VariableContainer<T> : BaseVariableContainer where T : BaseVariable
    {
        public override BaseVariable Variable => variable;
        public override float Value { get => value; internal set => this.value = Mathf.Max(value, variable.MinValue); }

        [SerializeField, HideInInspector] private string name;
        
        [SerializeField] protected T variable;
        [SerializeField] protected float value;

        public virtual void Update(string name)
        {
            this.name = name;
        }
    }
}
