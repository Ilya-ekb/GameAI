using Models.CharacterModel;
using System.Collections.Generic;

namespace BehaviourTree
{
    public class NodeRandom : NodeCombiner
    {
        private NodeRoot lastRunningNode;
        
        public NodeRandom() : base(NodeType.Random) { }

        public override ResultType Execute(ICharacter character)
        {
            List<int> randomList = GetRandom(nodeChildList.Count);
            
            int index = -1;
            if(lastRunningNode != null)
            {
                index = lastRunningNode.NodeIndex;
            }
            lastRunningNode = null;

            ResultType result = ResultType.Fail;
            while (randomList.Count > 0)
            {
                if (index > 0)
                {
                    index = randomList[randomList.Count - 1];
                    randomList.RemoveAt(randomList.Count - 1);
                }
                NodeRoot nodeRoot = nodeChildList[index];
                index = -1;
                result = nodeRoot.Execute(character);

                if (result == ResultType.Fail)
                {
                    continue;
                }
                if (result == ResultType.Success)
                {
                    break;
                }
                if (result == ResultType.Running)
                {
                    lastRunningNode = nodeRoot;
                    break;
                }
            }

            return result;
        }

        private List<int> GetRandom(int count)
        {
            List<int> resultList = new List<int>(count);
            List<int> tempList = new List<int>(count);
            for(int i =0; i < count; i++)
            {
                tempList.Add(i);
            }

            System.Random random = new System.Random();
            while (tempList.Count > 0)
            {
                int index = random.Next(0, (tempList.Count - 1));
                resultList.Add(tempList[index]);
                tempList.RemoveAt(index);
            }
            return resultList;
        }
    }
}
