using BehaviourTree.Data;

using Models.CharacterModel;
using System.Collections.Generic;

namespace BehaviourTree.Core
{
    public class NodeRandom : NodeCombiner
    {
        private NodeRoot lastRunningNode;
        
        public NodeRandom(NodeData data) : base(NodeType.Random, data) { }

        public override ResultType Execute(ICharacter character)
        {
            var randomList = GetRandom(nodeChildList.Count);
            
            var index = -1;
            if(lastRunningNode != null)
            {
                index = lastRunningNode.NodeIndex;
            }
            lastRunningNode = null;

            var result = ResultType.Fail;
            while (randomList.Count > 0)
            {
                if (index > 0)
                {
                    index = randomList[randomList.Count - 1];
                    randomList.RemoveAt(randomList.Count - 1);
                }
                var nodeRoot = nodeChildList[index];
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

        private static List<int> GetRandom(int count)
        {
            var resultList = new List<int>(count);
            var tempList = new List<int>(count);
            for(int i =0; i < count; i++)
            {
                tempList.Add(i);
            }

            var random = new System.Random();
            while (tempList.Count > 0)
            {
                var index = random.Next(0, (tempList.Count - 1));
                resultList.Add(tempList[index]);
                tempList.RemoveAt(index);
            }
            return resultList;
        }
    }
}
