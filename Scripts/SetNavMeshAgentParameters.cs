using Z3.NodeGraph.Tasks;
using Z3.NodeGraph.Core;
using UnityEngine.AI;
using UnityEngine;

namespace Z3.NodeGraph.TaskPack.AiNavigation
{
    [System.Serializable]
    public class AIPathParameters
    {
        public float maxSpeed = 10f;
        public float rotationSpeed = 360f;
        public float slowdownDistance = 3f;
        [Min(0.4f)]
        public float endReachedDistance = 2f;
        //pickNextWaypointDist = ?;
    }

    [NodeCategory(Categories.AiNavigation)]
    [NodeDescription("Set the parameters defined in IAstarAI")]
    public class SetNavMeshAgentParameters : ActionTask<NavMeshAgent>
    {
        public Parameter<AIPathParameters> aiPathParameters;

        public override string Info => $"NavAgent Parameters = {aiPathParameters}";

        protected override void StartAction()
        {
            Agent.speed = aiPathParameters.Value.maxSpeed;
            Agent.angularSpeed = aiPathParameters.Value.rotationSpeed;
            //Agent.stoppingDistance = aiPathParameters.Value.slowdownDistance; Update?
            Agent.stoppingDistance = aiPathParameters.Value.endReachedDistance;

            EndAction();
        }
    }
}