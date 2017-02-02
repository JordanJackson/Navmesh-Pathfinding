using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using System;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[NodeInfo(category ="Custom/", icon = "DefaultAsset", description = "Grunt Idle")]
public class GruntIdleActionNode : ActionNode 
{

    public FsmEvent wanderEvent;

    UnityEngine.AI.NavMeshAgent navMeshAgent;

    public override void Reset()
    {
        wanderEvent = new ConcreteFsmEvent();

        navMeshAgent = owner.root.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override Status Update()
    {
        if (false)
        {
            if (wanderEvent.id != 0)
            {
                owner.root.SendEvent(wanderEvent.id);
                return Status.Success;
            }
            return Status.Failure;
        }
        return Status.Running;
    }
}
