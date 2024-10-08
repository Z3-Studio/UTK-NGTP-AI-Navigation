﻿using Z3.NodeGraph.Tasks;
using Z3.NodeGraph.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Z3.NodeGraph.TaskPack.AiNavigation
{
    [NodeCategory(Categories.AiNavigation)]
    [NodeDescription("TODO")]
    public class MoveToTarget : ActionTask
    {
        [ParameterDefinition(AutoBindType.SelfBind)]
        [SerializeField] private Parameter<NavMeshAgent> data;
        [SerializeField] private Parameter<Vector3> target;

        public override string Info => $"Move To {target}";

        protected override void StartAction()
        {
            //Agent.canMove = true;
            //Agent.canSearch = true;
        }

        protected override void UpdateAction()
        {
            data.Value.destination = target.Value;

            // TODO: Review it. Create extension method Agent.ReachedDestination()
            if (Vector3.Distance(data.Value.destination, data.Value.transform.position) < 0.1f)
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