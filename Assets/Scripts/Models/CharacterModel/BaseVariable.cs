using System;

using UnityEngine;

namespace Models.CharacterModel
{
    [Serializable]
    public abstract class BaseVariable : ScriptableObject, IVariable
    {
        public abstract float MaxValue { get; }
        public abstract float MinValue { get; }

    }

    public enum ConditionAttribute
    {
        Healthy,
        Energy,
        Sentiment,
        Knowledge
    }
}
