using Models.CharacterModel.Conditions;

using System;

using UnityEngine;

namespace Models
{
    [Serializable]
    public class VariableContainer<T> where T : BaseVariable
    {
        public T Variable => variable;
        public virtual float Value { get => value; set => this.value = Mathf.Max(value, variable.MinValue); }


        [SerializeField, HideInInspector] private string name;
        
        [SerializeField] protected T variable;
        [SerializeField] protected float value;

        public virtual void Update(string name)
        {
            this.name = name;
        }
    }
}
