using System;
using System.Collections.Generic;
using System.Linq;
using Models.CharacterModel.Data;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public class RayVisionBehaviour : BaseVisionBehaviour<LayerMask>
    {
        private readonly float viewRadius;
        private readonly float viewAngle;
        private readonly Dictionary<VisibleTarget, float> validVisibleTarget = new Dictionary<VisibleTarget, float>();  

        [SerializeField] private int targetStorage = 5;

        [SerializeField] private LayerMask targetMask;
        [SerializeField] private LayerMask obstacleMask;

        public RayVisionBehaviour(VisionData data) : base(data)
        {
            viewAngle = data.ViewAngle;
            viewRadius = data.ViewRadius;
        }

        protected override VisibleTarget[] FindVisibleTargets()
        {
            var headPosition = lookingTransform.position;

            RefreshValidTarget();

            for (var t = 0; t < validVisibleTarget.Count; t++)
            {
                validVisibleTarget[validVisibleTarget.ElementAt(t).Key] = Mathf.Infinity;
            }

            Collider[] targetsInViewRadius = new Collider[targetStorage];
            _ = Physics.OverlapSphereNonAlloc(lookingTransform.position, viewRadius, targetsInViewRadius, targetMask);

            foreach (var target in targetsInViewRadius)
            {
                if (target == null){ continue;}

                var visibleTarget = new VisibleTarget(target.transform);
                if (!IsVisible(headPosition, visibleTarget))
                {
                    continue;
                }

                var distanceToTarget = Vector3.Distance(headPosition, visibleTarget.Position);

                if (validVisibleTarget.ContainsKey(visibleTarget))
                {
                    validVisibleTarget[visibleTarget] = distanceToTarget;
                }
                else
                {
                    validVisibleTarget.Add(visibleTarget, distanceToTarget);
                }
            }

            return validVisibleTarget.Keys.ToArray();
        }

        private void RefreshValidTarget()
        {
            var resultCount = validVisibleTarget.Count - targetStorage;
            if (resultCount <= 0) { return;}

            for(var i = 0; i < resultCount; i++)
            {
                validVisibleTarget.Remove(validVisibleTarget.ElementAt(i).Key);
            }
        }

        private bool IsVisible(Vector3 headPosition, VisibleTarget target)
        {
            Vector3 directionToTarget = (target.Position - headPosition).normalized;
            var angle = Vector3.Angle(lookingTransform.forward, directionToTarget);
            var cast = Physics.Raycast(headPosition, directionToTarget, viewRadius, obstacleMask);
            return angle < viewAngle / 2 && !cast;
        }

        protected override VisibleTarget NearestTarget()
        {
            return validVisibleTarget.FirstOrDefault(e=> e.Value == validVisibleTarget.Min(e=>e.Value)).Key;
        }

    }
}
