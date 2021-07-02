using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.CharacterIndicator
{
    public class Health : IInternalCondition
    {
        public float Value => value;

        private float value;

        public Health(float startHealt)
        {
            value = startHealt;
        }

        public void Increase(float value)
        {
            this.value = Mathf.Clamp(this.value + value, .0f, 100.0f);
        }

        public void Reduce(float value)
        {
            this.value = Mathf.Clamp(this.value - value, .0f, 100.0f);
        }
    }
}
