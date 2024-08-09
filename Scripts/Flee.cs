using Z3.NodeGraph.Tasks;
using Z3.NodeGraph.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Z3.NodeGraph.TaskPack.AiNavigation
{
    [NodeCategory(Categories.AiNavigation)]
    [NodeDescription("TODO")]
    public class Flee : ActionTask
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        [SerializeField] private Parameter<NavMeshAgent> data;
        [SerializeField] private Parameter<Vector3> target;
        [SerializeField] private Parameter<float> escapeDistance;

        protected override void StartAction()
        {
            //Agent.canMove = true;
            //Agent.canSearch = true;
        }

        protected override void UpdateAction()
        {
            Vector3 oppositeDirection = (data.Value.transform.position - target.Value).normalized * escapeDistance.Value;
            data.Value.destination = data.Value.transform.position + oppositeDirection;

            if (Vector3.Distance(data.Value.transform.position, target.Value) >= escapeDistance.Value)
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