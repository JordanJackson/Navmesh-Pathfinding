using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourMachine;
using System;

[NodeInfo(category = "Action/Enemy/", icon = "DefaultAsset", description = "Move to Target")]
public class MoveToTarget : ActionNode
{

    [VariableInfo(requiredField = false, tooltip = "Target to pursue.")]
    GameObjectVar targetVar;

    GameObject target;

    public override void Reset()
    {
        
    }

    public override Status Update()
    {
        if (targetVar == null || target == null)
        {
            targetVar = blackboard.GetGameObjectVar("Target");
            target = targetVar.Value;

            if (target == null)
            {
                Debug.LogError("Target is null.");
                return Status.Failure;
            }
        }
        

        NavMeshAgent agent = owner.root.GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent is null.");
            return Status.Failure;
        }
        NavMeshPath path = new NavMeshPath();
        if (path == null)
        {
            Debug.LogError("What the fuck is this?");
        }
        bool success = agent.CalculatePath(target.transform.position, path);
        if (success)
        {
            agent.SetPath(path);
            return Status.Success;
        }
        else
        {
            Debug.LogError("No path found.");
            return Status.Failure;
        }
    }
}
