using Models;
using Models.CharacterModel;
using Models.CharacterModel.Behaviour.MoveModel;
using Models.CharacterModel.Behaviour.VisionModel;
using Models.CharacterModel.Conditions;
using Models.Resources;
using UnityEngine;
using UnityEngine.AI;

// ReSharper disable once CheckNamespace
public class Student : MovableCharacter
{
    public float Period;
    private float timer;

    public GameResource Food;
    public GameResource Bread;
    public Condition Energy;

    public Transform CookTransform;
    public Transform EatTransform;

    protected override void Start()
    {
        base.Start();
        MoveBehaviour = new NavMeshMoveBehaviour(GetComponent<NavMeshAgent>());
        VisionBehaviour = new RayVisionBehaviour(visionData);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    private bool once = false;
    protected override void Update()
    {
        if (FindContainer(Food).Value > 0 && FindContainer(Energy).Value <= 90 && FindContainer(Bread).Value <= 0)
        {
            SetTarget(EatTransform.position);
        }

        if (FindContainer(Food).Value == 0 && FindContainer(Energy).Value <= 90)
        {
            SetTarget(CookTransform.position);
        }

        if (FindContainer(Energy).Value == 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (!once)
            {
                once = true;
                gameObject.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity * 10);
            }

            (MoveBehaviour as NavMeshMoveBehaviour)?.DisableAgent();
        }

        base.Update();
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
