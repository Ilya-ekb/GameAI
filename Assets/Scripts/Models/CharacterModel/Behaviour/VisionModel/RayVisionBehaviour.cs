using System;
using System.Collections.Generic;
using System.Linq;
using Models.CharacterModel.Data;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    [Serializable]
    public class RayVisionBehaviour : BaseVisionBehaviour
    {
        private LayerMask targetMask;
        private LayerMask obstacleMask;

        public RayVisionBehaviour(Transform lookingTransform, VisionData data) : base(lookingTransform, data)
        {
            targetMask = (data as RayVisionData) .TargetMask;
            obstacleMask = (data as RayVisionData).ObstableMask;
        }

        public override Target[] FindVisibleTargets()
        {
            var headPosition = lookingTransform.position;

            RefreshValidTarget();

            UpdateDistance();

            Collider[] targetsInViewRadius = new Collider[targetStorage];
            _ = Physics.OverlapSphereNonAlloc(lookingTransform.position, viewRadius, targetsInViewRadius, targetMask);

            foreach (var target in targetsInViewRadius)
            {
                if (target == null) { continue; }

                if (!IsVisible(headPosition, target.transform))
                {
                    continue;
                }

                var distanceToTarget = Vector3.Distance(headPosition, target.transform.position);

                var visibleTarget = validVisibleTarget.Where(e => e.Key.Id == target.transform.GetHashCode().ToString()).FirstOrDefault();

                if(visibleTarget.Key == null)
                {
                    validVisibleTarget.Add(new Target(target.transform), distanceToTarget);
                }
                else
                {
                    validVisibleTarget[visibleTarget.Key] = distanceToTarget;
                }
            }

            return validVisibleTarget.Keys.ToArray();
        }

        private void UpdateDistance()
        {
            for (var t = 0; t < validVisibleTarget.Count; t++)
            {
                var validTarget = validVisibleTarget.ElementAt(t);
                validVisibleTarget[validTarget.Key] = Vector3.Distance(validTarget.Key.Position, lookingTransform.position);
            }
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

        private bool IsVisible(Vector3 headPosition, Transform target)
        {
            Vector3 directionToTarget = (target.position - headPosition).normalized;
            var angle = Vector3.Angle(lookingTransform.forward, directionToTarget);
            var cast = Physics.Raycast(headPosition, directionToTarget, viewRadius, obstacleMask);
            return angle < viewAngle / 2 && !cast;
        }

        public override Target NearestTarget()
        {
            return validVisibleTarget.FirstOrDefault(e=> e.Value == validVisibleTarget.Min(e=>e.Value)).Key;
        }

    }
}
