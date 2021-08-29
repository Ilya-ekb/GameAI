using Models.CharacterModel.KnowlergeModel;

namespace Models.CharacterModel.Behaviour
{
    public abstract class ActionEventObject : BaseEventObject
    {
        protected float ComputeChangeValue(ICharacter character, Knowlerge[] knowlerges)
        {
            float result = 0.0f;
            foreach (var knowlerge in knowlerges)
            {
                var knowlergeContainer = character.FindContainer(knowlerge);
                result += knowlergeContainer.Value;
            }

            return result;
        }
    }
}
