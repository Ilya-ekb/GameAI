using System.Collections.Generic;
using System.Linq;
using BehaviourTree.Core;
using Models.CharacterModel.Data;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public class BaseVariableVisionBehaviour : RayVisionBehaviour
    {
        private readonly BaseVariable[] baseVariables;

        public BaseVariableVisionBehaviour(Transform lookingTransform, VisionData data = null) : base(lookingTransform,
            data)
        {
            if (!(data is BaseVariableVisionData bvData))
            {
                return;
            }

            baseVariables = bvData.BaseVariables;
        }

        public override Target NearestTarget(ref ResultType resultType)
        {
            Target result = null;
            if (baseVariables == null)
            {
                return null;
            }

            var temp = validVisibleTarget
                .Where(item =>
                    (1 << item.Key.Transform.gameObject.layer & targetMask) != 0 &&
                    item.Key.BaseVariableContainer != null).ToDictionary(item => item.Key, item => item.Value);

            if (temp.Count == 0)
            {
                return result;
            }

            foreach (var item in temp.Where(item =>
                !baseVariables.All(variable => item.Key.BaseVariableContainer.Any(e => e.Variable == variable))))
            {
                temp.Remove(item.Key);
            }

            var acceptedTargetDistancePair = temp.ToArray();
            if (acceptedTargetDistancePair.Length > 0)
            {
                var minDist = acceptedTargetDistancePair.Min(targetDistancePair => targetDistancePair.Value);
                result = acceptedTargetDistancePair
                    .FirstOrDefault(targetPair => Mathf.Approximately(targetPair.Value, minDist)).Key;
            }

            if (result != null)
            {
                resultType = ResultType.Success;
            }

            return result;
        }
    }
}
