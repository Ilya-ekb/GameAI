using Models;
using Models.CharacterModel;
using Models.CharacterModel.Behaviour.MoveModel;
using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.Conditions;
using Models.CharacterModel.Data;
using Models.Resources;
using UnityEngine;
using UnityEngine.AI;

// ReSharper disable once CheckNamespace
public class Student : MovableCharacter
{
    public float Period;
    private float timer;
    [SerializeField] private Transform head;

    protected override void Start()
    {
        base.Start();
        MoveBehaviour = new NavMeshMoveBehaviour(GetComponent<NavMeshAgent>());
        VisionBehaviour = new RayVisionBehaviour(head);
    }

    protected override void Update()
    {
        base.Update();

        OutcomeEnergy();
    }

    private void OutcomeEnergy()
    {
        if (timer <= 0)
        {
            foreach (var condition in Conditions)
            {
                condition.Value -= .05f;
            }

            timer = Period;
        }

        timer -= Time.deltaTime;
    }
}
