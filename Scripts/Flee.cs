using Z3.NodeGraph.Tasks;
using Z3.NodeGraph.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Z3.NodeGraph.TaskPack.AiNavigation
{
    [NodeCategory(Categories.AiNavigation)]
    [NodeDescription("TODO")]
    public class Flee : ActionTask<NavMeshAgent>
    {
        public Parameter<Vector3> target;
        public Parameter<float> escapeDistance;

        protected override void StartAction()
        {
            //Agent.canMove = true;
            //Agent.canSearch = true;
        }

        protected override void UpdateAction()
        {
            Vector3 oppositeDirection = (Agent.transform.position - target.Value).normalized * escapeDistance.Value;
            Agent.destination = Agent.transform.position + oppositeDirection;

            if (Vector3.Distance(Agent.transform.position, target.Value) >= escapeDistance.Value)
            {
                EndAction();
            }
        }

        protected override void StopAction()
        {
            //Agent.canMove = false;
            //Agent.canSearch = false;
        }
    }
}