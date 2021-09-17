using System.Collections.Generic;
using System.Linq;
using Models.CharacterModel.Data;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public class BaseVariableVisionBehaviour : RayVisionBehaviour
    {
        private readonly BaseVariable[] baseVariables;
        public BaseVariableVisionBehaviour(Transform lookingTransform, VisionData data = null) : base(lookingTransform, data)
        {
            if (!(data is BaseVariableVisionData bvData))
            {
                return;
            }
            baseVariables = bvData.BaseVariables;
        }

        public override Target NearestTarget()
        {
            if (baseVariables == null)
            {
                return null;
            }

            var temp = validVisibleTarget.Where(e => (1 << e.Key.Transform.gameObject.layer & targetMask) != 0 &&
                                                     baseVariables.Any(variable =>
                                                         e.Key.BaseVariableContainer.Any(b => b.Variable == variable)));

            var acceptedTargetDistancePair= temp as KeyValuePair<Target, float>[] ?? temp.ToArray();
            var minDist = acceptedTargetDistancePair.Min(targetDistancePair => targetDistancePair.Value);
            var result = acceptedTargetDistancePair.FirstOrDefault(targetPair => Mathf.Approximately(targetPair.Value, minDist));

            return result.Key;
        }
    }
}
