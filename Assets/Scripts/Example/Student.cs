using UnityEngine;
using BehaviourTree;
using UnityEngine.AI;

public class Student : MonoBehaviour
{
    public NavMeshAgent Agent { get; set; }
    public bool IsHungry => energy <= minEnergy;
    public bool IsFull => energy >= maxEnergy;
    public bool HasFood => food > minFood;
    public bool FoodEnough => food >= maxFood;

    private NodeSelect rootNode = new NodeSelect();

    private float energy = .0f;
    private float minEnergy = 50.0f;
    private float maxEnergy = 100.0f;

    private float food = .0f;
    private float minFood = 0.0f;
    private float maxFood = 100.0f;

    private void Start()
    {
        Initiate();
    }

    private void Update()
    {
        ChangeEnergy(-.02f);
        rootNode.Execute();
        Debug.Log(this);
    }

    /// <summary>
    /// Initialize adding behaviour tree
    /// </summary>
    private void Initiate()
    {
        Agent = GetComponent<NavMeshAgent>();
        NodeSequence nodeSequence_1 = new NodeSequence();

        rootNode.AddNode(nodeSequence_1);

        NodeConditionHungry nodeConditionHungry_1_1 = new NodeConditionHungry();
        nodeConditionHungry_1_1.SetStudent(this);
        nodeSequence_1.AddNode(nodeConditionHungry_1_1);

        NodeSelect nodeSelect_1_2 = new NodeSelect();
        nodeSequence_1.AddNode(nodeSelect_1_2);

        NodeConditionHasFood nodeConditionHasFood_1_2_1 = new NodeConditionHasFood();
        nodeConditionHasFood_1_2_1.SetStudent(this);
        nodeSelect_1_2.AddNode(nodeConditionHasFood_1_2_1);

        NodeSequence nodeSequence_1_2_2 = new NodeSequence();
        nodeSelect_1_2.AddNode(nodeSequence_1_2_2);

        NodeActionMove nodeActionMove_1_2_2_1 = new NodeActionMove();
        nodeActionMove_1_2_2_1.SetStudent(this);
        nodeActionMove_1_2_2_1.SetTarget("Cooking");
        nodeSequence_1_2_2.AddNode(nodeActionMove_1_2_2_1);

        NodeActionCooking nodeActionCooking_1_2_2_2 = new NodeActionCooking();
        nodeActionCooking_1_2_2_2.SetStudent(this);
        nodeSequence_1_2_2.AddNode(nodeActionCooking_1_2_2_2);

        NodeActionMove nodeActionMove_1_3 = new NodeActionMove();
        nodeActionMove_1_3.SetStudent(this);
        nodeActionMove_1_3.SetTarget("Eat");
        nodeSequence_1.AddNode(nodeActionMove_1_3);

        NodeActionEat nodeActionEat_1_4 = new NodeActionEat();
        nodeActionEat_1_4.SetStudent(this);
        nodeSequence_1.AddNode(nodeActionEat_1_4);
    }

    public override string ToString()
    {
        return $"Student:  energy {energy} food {food}";
    }

    public void AddEnergy(float value)
    {
        ChangeEnergy(value);
        Debug.Log("Eat");
    }
    
    private void ChangeEnergy(float value)
    {
        energy += value;
    }

    public void Cooking(float value)
    {
        ChangeFood(value);
        Debug.Log("Cooking");
    }

    public void ChangeFood(float value)
    {
        food += value;
    }
}
