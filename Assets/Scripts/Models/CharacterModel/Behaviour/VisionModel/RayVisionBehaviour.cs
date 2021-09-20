using System;
using System.Collections.Generic;
using System.Linq;
using BehaviourTree.Core;
using Models.CharacterModel.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    [Serializable]
    public class RayVisionBehaviour : BaseVisionBehaviour
    {
        
        protected LayerMask targetMask;
        protected LayerMask obstacleMask;
        private const float rotationStep = 360;
        private Quaternion targetRotation;
        public Func<Target, bool> CheckTargetFunc;

        public RayVisionBehaviour(Transform lookingTransform, VisionData data = null) : base(lookingTransform, data)
        {
            targetRotation = lookingTransform.rotation;

            if (!(data is RayVisionData visionData))
            {
                return;
            }

            targetMask = visionData.TargetMask;
            obstacleMask = visionData.ObstacleMask;
        }

        public override void UpdateData(VisionData data)
        {
            base.UpdateData(data);
            if (!(data is RayVisionData visionData))
            {
                return;
            }
            targetMask = visionData.TargetMask;
            obstacleMask = visionData.ObstacleMask;
        }

        public override void FindVisibleTargets()
        {
            var headPosition = lookingTransform.position;

            RefreshValidTarget();

            UpdateDistance();

            var targetsInViewRadius = new Collider[targetStorage];
            _ = Physics.OverlapSphereNonAlloc(lookingTransform.position, viewRadius, targetsInViewRadius, targetMask);

            foreach (var target in targetsInViewRadius)
            {
                if (target == null) { continue; }

                if (!IsVisible(headPosition, target.transform) || target.transform == lookingTransform.transform || target.transform == lookingTransform.transform.parent)
                {
                    continue;
                }

                var distanceToTarget = Vector3.Distance(headPosition, target.transform.position);

                var visibleTarget = validVisibleTarget.FirstOrDefault(e => e.Key.Id == target.transform.GetHashCode().ToString());

                if (CheckTargetFunc != null)
                {
                    if (!CheckTargetFunc.Invoke(visibleTarget.Key))
                    {
                        continue;
                    }
                }

                if (visibleTarget.Key == null)
                {
                    validVisibleTarget.Add(new Target(target.transform), distanceToTarget);
                }
                else
                {
                    validVisibleTarget[visibleTarget.Key] = distanceToTarget;
                }
            }
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

        public override Target NearestTarget(ref ResultType resultType)
        {
            var temp = validVisibleTarget.Where(e => (1 << e.Key.Transform.gameObject.layer & targetMask) != 0);

            var acceptedTargetDistancePair = temp as KeyValuePair<Target, float>[] ?? temp.ToArray();
            
            var result = acceptedTargetDistancePair.FirstOrDefault(targetPair =>
                Mathf.Approximately(targetPair.Value, acceptedTargetDistancePair.Min(targetDistancePair => targetDistancePair.Value))).Key;
            
            if (result != null)
            {
                resultType = ResultType.Success;
            }

            return result;
        }

        public override Target RandomTarget(ref ResultType resultType)
        {
            Target target = null;
            resultType = ResultType.Running;
            var angel = Quaternion.Angle(targetRotation, lookingTransform.rotation);
            var value = Random.Range(-rotationStep, rotationStep);
            if ( angel < 1f)
            {
                value += lookingTransform.rotation.y * Mathf.Rad2Deg;
                targetRotation = Quaternion.AngleAxis(value, Vector3.up);
            }
            else
            {
                lookingTransform.rotation = Quaternion.RotateTowards(lookingTransform.rotation, targetRotation, 2f);
            }
            return target;
        }
    }
}
