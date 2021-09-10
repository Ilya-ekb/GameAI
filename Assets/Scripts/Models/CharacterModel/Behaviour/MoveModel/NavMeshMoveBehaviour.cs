using System.Collections;
using System.Collections.Generic;
using Models.CharacterModel;
using UnityEngine;
using UnityEngine.AI;

namespace Models.CharacterModel.Behaviour.MoveModel
{
    public class NavMeshMoveBehaviour : IMoveBehaviour
    {
        public Vector3 Velocity => agent.velocity;
        public Vector3 Destination => agent.destination;

        public Vector3 CurrentPosition => agent.transform.position + Vector3.down * (agent.height / 2);

        private readonly NavMeshAgent agent;

        public NavMeshMoveBehaviour(NavMeshAgent agent)
        {
            this.agent = agent;
        }

        public void SetDestination(Vector3 destination)
        {
            if (!agent || !agent.enabled)
            {
                return;
            }
            if (!agent.destination.Equals(destination))
            {
                agent.SetDestination(destination);
            }
        }

        public void StopMove()
        {
            if (!agent || !agent.enabled)
            {
                return;
            }

            agent.SetDestination(agent.nextPosition);
        }

        public void DisableAgent()
        {
            agent.enabled = false;
        }
    }
}
