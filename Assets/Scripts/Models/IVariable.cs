using Models.CharacterModel.Conditions;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Models
{
    public interface IVariable 
    {
        float MaxValue { get; }
        float MinValue { get; }
    }

    public enum CompairMode 
    {
        Equals,
        NotEquals,
        Greater,
        Less,
        GreaterOrEquals,
        LessOrEquals
    }

    public static class CompairAction<T> where T : BaseVariable
    {
        public static readonly Dictionary<CompairMode, Func<VariableContainer<T>, VariableContainer<T>, bool>> Compairs =
            new Dictionary<CompairMode, Func<VariableContainer<T>, VariableContainer<T>, bool>>
            {
                {CompairMode.Equals, (a, b) => a.Value == b.Value },
                {CompairMode.Greater, (a, b) => b.Value > a.Value },
                {CompairMode.Less, (a, b) => b.Value < a.Value },
                {CompairMode.NotEquals, (a, b) => b.Value != a.Value },
                {CompairMode.GreaterOrEquals, (a, b) => b.Value >= a.Value },
                {CompairMode.LessOrEquals, (a, b) => b.Value <= a.Value },
            };
    }
}
