using Models.CharacterModel;

namespace Models
{
    public abstract class BaseVariableContainer
    {
        public abstract BaseVariable Variable { get; }
        public abstract float Value { get; internal set; }
    }
}
