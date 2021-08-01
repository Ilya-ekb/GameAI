using UnityEngine;
using BehaviourTree;
using Character;

public class NodeActionCooking : NodeAction
{
    private Student student;
    public override ResultType Execute(ICharacter character)
    {
        if (student.FoodEnough)
        {
            return ResultType.Success;
        }
        student.Cooking(.5f);
        return ResultType.Running;
    }

    public void SetStudent(Student student) => this.student = student;
}
