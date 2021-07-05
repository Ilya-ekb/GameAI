using UnityEngine;
using BehaviourTree;

public class Student : MonoBehaviour
{
    public bool IsHungry => energy <= minEnergy;
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
        
    }

    /// <summary>
    /// Initialize adding behaviour tree
    /// </summary>
    private void Initiate()
    {
        NodeSequence nodeSequence_1 = new NodeSequence();

        rootNode.AddNode(nodeSequence_1);

        NodeConditionHungry nodeConditionHungry_1_1 = new NodeConditionHungry();
        nodeConditionHungry_1_1.SetStudent(this);
        nodeSequence_1.AddNode(nodeConditionHungry_1_1);

        NodeSelect nodeSelect_1_2 = new NodeSelect();
        nodeSequence_1.AddNode(nodeSelect_1_2);


    }
}
