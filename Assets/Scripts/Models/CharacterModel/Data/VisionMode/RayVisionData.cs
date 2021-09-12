using System.Collections;
using UnityEngine;

namespace Models.CharacterModel.Data
{
    [CreateAssetMenu(fileName = "Ray Vision Data", menuName = "Character/Data/VisionData/Ray Vision Data")]
    public class RayVisionData : VisionData
    {
        public LayerMask TargetMask;
        public LayerMask ObstacleMask;
    }
}
