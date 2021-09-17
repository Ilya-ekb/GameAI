using Models.CharacterModel;

using System;

using UnityEngine;

namespace Models
{
    [Serializable]
    public class VariableContainer<T> : BaseVariableContainer where T : BaseVariable
    {
        public VariableContainer(T variable, float value)
        {
            this.variable = variable;
            this.value = value;
        }
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
