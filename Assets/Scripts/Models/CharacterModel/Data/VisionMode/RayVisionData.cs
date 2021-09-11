using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel.Data
{
    [CreateAssetMenu(fileName = "Ray Vision Data", menuName = "Character/Data/Ray Vision Data")]
    public class RayVisionData : VisionData
    {
        public LayerMask TargetMask;
        public LayerMask ObstableMask;
    }
}
