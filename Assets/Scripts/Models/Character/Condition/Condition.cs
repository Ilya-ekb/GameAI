using UnityEngine;

namespace Character.Condition
{
    public class Condition : ScriptableObject, ICondition
    {
        public float Value => value;

        public bool Full => value >= maxValue;

        [SerializeField] private float maxValue = 100.0f;
        [SerializeField] private float minValue = 0.0f;
        [SerializeField] private float value;

        public virtual void Change(float value)
        {
            this.value = Mathf.Clamp(this.value + value, minValue, maxValue);
        }
    }
}
