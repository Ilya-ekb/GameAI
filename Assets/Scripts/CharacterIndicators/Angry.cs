using System;
using UnityEngine;
using Character.CharacterResources;

namespace Character.CharacterIndicator
{
    public class Angry : Condition
    {
        public Angry(float startValue) : base(startValue, ConditionType.Angry) { }
    }
}
