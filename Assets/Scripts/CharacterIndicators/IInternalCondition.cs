using Character.CharacterResources;

namespace Character.CharacterIndicator
{
    public interface IInternalCondition
    {
        float Value { get; }
        bool Full { get; }
        ICharacterResource RestoringResource { get; }
        void Increase(float value);
        void Reduce(float value);
    }
}
