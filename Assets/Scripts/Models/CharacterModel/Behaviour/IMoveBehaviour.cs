using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models.CharacterModel
{
    public interface IMoveBehaviour
    {
        Vector3 Velocity { get; }
        Vector3 Destination { get; }
        Vector3 CurrentPosition { get; }
        void SetDestination(Vector3 destination);
        void StopMove();
    }
}
