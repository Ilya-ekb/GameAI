using Models.CharacterModel.Data;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public class BaseVisionBehaviour<T> : MonoBehaviour
    {
        protected Transform lookingTransform;
        public BaseVisionBehaviour(VisionData data) { }

        protected virtual VisibleTarget[] FindVisibleTargets() => null;

        protected virtual VisibleTarget NearestTarget() => default;
    }
}
