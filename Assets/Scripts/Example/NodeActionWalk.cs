using BehaviourTree;

using Character;

public class NodeActionWalk : NodeAction
{

    private Student student;
    public override ResultType Execute(ICharacter character)
    {
        if (!student.IsHungry)
        {

        }
        return ResultType.Fail;
    }
}
