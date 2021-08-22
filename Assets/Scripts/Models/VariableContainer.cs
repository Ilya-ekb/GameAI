using System;

using UnityEngine;

namespace Models
{
    [Serializable]
    public class VariableContainer<T> where T: IVariable 
    {
        public CompairMode CompairMode => compairMode;
        public T Variable => variable;
        public float Value => value;

        
        private string name;
        [SerializeField] protected T variable;
        [SerializeField] protected CompairMode compairMode;
        [SerializeField] protected float value;

        public virtual void Change(float value)
        {
            this.value = Mathf.Clamp(this.value + value, variable.MinValue, variable.MaxValue);
        }

        public virtual void Update(string name)
        {
            this.name = name;
        }
    }
}
