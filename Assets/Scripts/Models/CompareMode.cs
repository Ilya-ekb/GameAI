using Models.CharacterModel;
using System;
using System.Collections.Generic;

namespace Models
{
    public enum CompareMode 
    {
        Equals,
        NotEquals,
        Greater,
        Less,
        GreaterOrEquals,
        LessOrEquals
    }

    public static class CompareAction<T> where T : BaseVariable
    {
        private const float tolerance = .01f;

        public static readonly Dictionary<CompareMode, Func<BaseVariableContainer, VariableContainer<T>, bool>> Compares =
            new Dictionary<CompareMode, Func<BaseVariableContainer, VariableContainer<T>, bool>>
            {
                {CompareMode.Equals, (a, b) => Math.Abs(a.Value - b.Value) < tolerance },
                {CompareMode.Greater, (a, b) => a.Value > b.Value },
                {CompareMode.Less, (a, b) => a.Value < b.Value },
                {CompareMode.NotEquals, (a, b) => Math.Abs(a.Value - b.Value) > tolerance },
                {CompareMode.GreaterOrEquals, (a, b) => a.Value >= b.Value },
                {CompareMode.LessOrEquals, (a, b) => a.Value <= b.Value },
            };
    }
}
