using UnityEngine;

namespace Models.CharacterModel.Data
{
    [CreateAssetMenu(fileName = "Base Variable Vision Data", menuName = "Character/Data/VisionData/Base Variable Vision Data")]
    public class BaseVariableVisionData : RayVisionData
    {
        public BaseVariable[] BaseVariables;
    }
}
