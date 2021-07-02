using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.CharacterIndicator
{
    public interface IInternalCondition
    {
        float Value { get; }

        void Increase(float value);
        void Reduce(float value);
    }
}
