using Models;
using Models.CharacterModel;
using Models.CharacterModel.Behaviour.MoveModel;
using Models.CharacterModel.Behaviour.VisionModel;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MovableCharacter
{
    public float Period;
    private float timer;
    [SerializeField] private Transform head;
    [SerializeField] private ToolbarItem energyToolbar;
    private BaseVariableContainer energyContainer;
    [SerializeField] private BaseVariable energy;
    [SerializeField] private ToolbarItem garbageToolbar;
    private BaseVariableContainer garbageContainer;
    [SerializeField] private BaseVariable garbage;
    [SerializeField] private ToolbarItem batteryToolbar;
    private BaseVariableContainer  batteryContainer;
    [SerializeField] private BaseVariable battery;

    protected override void Start()
    {
        base.Start();
        MoveBehaviour = new NavMeshMoveBehaviour(GetComponent<NavMeshAgent>());
        VisionBehaviour = new RayVisionBehaviour(head);

        energyContainer = GetContainerWith(energy);
        garbageContainer = GetContainerWith(garbage);
        batteryContainer = GetContainerWith(battery);
    }

    protected override void Update()
    {
        base.Update();

        OutcomeEnergy();
        UpdateToolbar();
    }

    private void OutcomeEnergy()
    {
        if (timer <= 0)
        {
            energyContainer.Value -= .05f;
            if (energyContainer.Value <= 0.0f)
            {
               DestroyImmediate(GetComponent<NavMeshAgent>());
               GetComponent<Rigidbody>().isKinematic = false;
               GetComponent<Rigidbody>().useGravity = true;
            }
            timer = Period;
        }

        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var variableSubject = other.GetComponent<IVariableSubject>();

        variableSubject?.Interaction(this);
    }

    private void UpdateToolbar()
    {
        energyToolbar?.Repaint(energyContainer.Value);
        garbageToolbar?.Repaint(garbageContainer.Value);
        batteryToolbar?.Repaint(batteryContainer.Value);
    }
}

