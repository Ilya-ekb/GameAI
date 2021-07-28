using Character.CharacterResources;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.CharacterIndicator
{
    public abstract class Condition : IInternalCondition
    {
        public ConditionType ConditionType => conditionType;
        public float Value => value;
        public bool Full => value >= maxValue;

        public ICharacterResource RestoringResource => resource;

        private float value;
        [SerializeField] private ConditionType conditionType;
        [SerializeField] private float maxValue = 100.0f;
        [SerializeField] private float minValue = 0.0f;
        [SerializeField] private CharacterResource resource;


        public Condition(float startValue, ConditionType conditionType)
        {
            value = startValue;
            this.conditionType = conditionType;
        }

        public void Increase(float value)
        {
            this.value = Mathf.Clamp(this.value + value, minValue, maxValue);
        }

        public void Reduce(float value)
        {
            this.value = Mathf.Clamp(this.value - value, minValue, maxValue);
        }
    }
    public enum ConditionType
    {
        Health,
        Anxiety,
        Angry
    }
}
