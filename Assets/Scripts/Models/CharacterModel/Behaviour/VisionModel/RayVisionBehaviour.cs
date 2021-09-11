using System;
using System.Linq;
using Models.CharacterModel.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    [Serializable]
    public class RayVisionBehaviour : BaseVisionBehaviour
    {
        private LayerMask targetMask;
        private LayerMask obstacleMask;
        private const float rotationStep = 90;
        private Quaternion targetRotation;

        public RayVisionBehaviour(Transform lookingTransform, VisionData data = null) : base(lookingTransform, data)
        {
            targetRotation = lookingTransform.rotation;

            if (!(data is RayVisionData visionData))
            {
                return;
            }


            targetMask = visionData.TargetMask;
            obstacleMask = visionData.ObstableMask;
        }

        public override void UpdateData(VisionData data)
        {
            base.UpdateData(data);
            if (!(data is RayVisionData visionData))
            {
                return;
            }
            targetMask = visionData.TargetMask;
            obstacleMask = visionData.ObstableMask;
        }

        public override Target[] FindVisibleTargets()
        {
            var headPosition = lookingTransform.position;

            RefreshValidTarget();

            UpdateDistance();

            var targetsInViewRadius = new Collider[targetStorage];
            _ = Physics.OverlapSphereNonAlloc(lookingTransform.position, viewRadius, targetsInViewRadius, targetMask);

            foreach (var target in targetsInViewRadius)
            {
                if (target == null) { continue; }

                if (!IsVisible(headPosition, target.transform))
                {
                    continue;
                }

                var distanceToTarget = Vector3.Distance(headPosition, target.transform.position);

                var visibleTarget = validVisibleTarget.FirstOrDefault(e => e.Key.Id == target.transform.GetHashCode().ToString());

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
            var directionToTarget = (target.position - headPosition).normalized;
            var angle = Vector3.Angle(lookingTransform.forward, directionToTarget);
            var cast = Physics.Raycast(headPosition, directionToTarget, viewRadius, obstacleMask);
            return angle < viewAngle / 2 && !cast;
        }

        public override Target NearestTarget()
        {
            var temp = validVisibleTarget.Where(e => (1 << e.Key.Transform.gameObject.layer & targetMask) != 0);
            return temp.FirstOrDefault(e=> Mathf.Approximately(e.Value, temp.Min(e => e.Value))).Key;
        }

        public override Target RandomTarget()
        {
            if (Quaternion.Angle(targetRotation, lookingTransform.rotation) < 1f)
            {
                var value = Random.Range(-rotationStep, rotationStep);
                value += lookingTransform.rotation.y * Mathf.Rad2Deg;
                targetRotation = Quaternion.AngleAxis(value, Vector3.up);
            }
            else
            {
                lookingTransform.rotation = Quaternion.Slerp(lookingTransform.rotation, targetRotation, Time.deltaTime);
            }
            return null;
        }
    }
}
