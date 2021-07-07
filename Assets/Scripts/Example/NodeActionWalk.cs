using BehaviourTree;

public class NodeActionWalk : NodeAction
{

    private Student student;
    public override ResultType Execute()
    {
        if (!student.IsHungry)
        {

        }
        return ResultType.Fail;
    }
}
