using Models.CharacterModel.Data;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public abstract class BaseVisionBehaviour
    {
        public Transform LookingTransform => lookingTransform;

        protected Transform lookingTransform;
        protected Dictionary<Target, float> validVisibleTarget = new Dictionary<Target, float>();

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
            GetValidTargets();
        }

        public abstract Target[] FindVisibleTargets();

        public abstract Target NearestTarget();

        public abstract Target RandomTarget();

        protected virtual void GetValidTargets()
        {
            validVisibleTarget =
                     validVisibleTarget.Where(e => e.Key.Transform.gameObject.activeSelf).ToDictionary(e=>e.Key, e=>e.Value);
        }
    }
}
