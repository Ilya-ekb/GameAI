namespace Character.CharacterIndicator
{
    public interface IKnowlerge : IInternalCondition
    {
       KnowlergeType KnowlergeType { get; }
    }
    public enum KnowlergeType 
    {
        Treatment,
        Shooting
    }

}

