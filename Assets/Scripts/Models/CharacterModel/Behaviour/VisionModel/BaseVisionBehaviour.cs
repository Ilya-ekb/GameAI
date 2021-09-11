using Models.CharacterModel.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public abstract class BaseVisionBehaviour 
    {
        public Transform LookingTransform => lookingTransform;

        protected Transform lookingTransform;
        protected readonly Dictionary<Target, float> validVisibleTarget = new Dictionary<Target, float>();

        protected float viewRadius;
        protected float viewAngle;
        protected int targetStorage = 5;

        protected BaseVisionBehaviour(Transform lookingTransform, VisionData data = null) 
        {
            this.lookingTransform = lookingTransform;
            if (data == null)
            {
                return;
            }

            viewAngle = data.ViewAngle;
            viewRadius = data.ViewRadius;
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

        public abstract Target[] FindVisibleTargets();

        public abstract Target NearestTarget();

        public abstract Target RandomTarget();
    }
}
