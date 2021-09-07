using System;
using System.Collections.Generic;
using Models.CharacterModel.Data;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    public class BaseVisionBehaviour
    {
        public BaseVisionBehaviour(VisionData data) { }

        protected virtual Transform[] FindVisibleTargets(string targetProperty) => null;

        protected virtual Vector3 NearestTarget(Transform[] visibleTargets) => default;
    }
}
