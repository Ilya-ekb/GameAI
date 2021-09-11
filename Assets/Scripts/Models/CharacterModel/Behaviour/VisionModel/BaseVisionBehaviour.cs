using Models.CharacterModel.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public class BaseVisionBehaviour 
    {
        public Transform LookingTransform => lookingTransform;

        protected Transform lookingTransform;
        protected float viewRadius;
        protected float viewAngle;
        protected readonly Dictionary<Target, float> validVisibleTarget = new Dictionary<Target, float>();

        protected int targetStorage = 5;

        public BaseVisionBehaviour(Transform lookingTransform, VisionData data = null) 
        {
            this.lookingTransform = lookingTransform;
            UpdateData(data);
        }

        public virtual void UpdateData(VisionData data)
        {
            if (data == null)
            {
                return;
            }
            viewAngle = data.ViewAngle;
            viewRadius = data.ViewRadius;
        }

        public virtual Target[] FindVisibleTargets() => null;

        public virtual Target NearestTarget() => default;
    }
}
