using System;
using Models.CharacterModel;

namespace Models
{
    [Serializable]
    public abstract class BaseVariableContainer
    {
        public abstract BaseVariable Variable { get; }
        public abstract float Value { get; internal set; }

        public ContainerState State =>
            Variable.MaxValue <= Value ? ContainerState.NotFully :
            Variable.MinValue >= Value ? ContainerState.Empty :
            ContainerState.NotFully;
    }
}
