using System.Collections;
using System.Collections.Generic;
using Models.CharacterModel.Behaviour;
using Models.CharacterModel.Data;
using UnityEngine;

namespace Models.CharacterModel.Behaviour
{
    public class RayVisionBehaviour : BaseVisionBehaviour
    {
        public RayVisionBehaviour(VisionData data) : base(data)
        {
        }

        protected override Transform[] FindVisibleTargets(string targetProperty)
        {
            throw new System.NotImplementedException();
        }

        protected override Vector3 NearestTarget(Transform[] visibleTargets)
        {
            throw new System.NotImplementedException();
        }

    }
}
