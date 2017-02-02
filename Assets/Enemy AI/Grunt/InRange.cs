using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Condition/Enemy/", icon = "DefaultAsset", description = "Target in range.")]
public class InRange : ConditionNode {

    public float attackRange;

    [VariableInfo(requiredField = false, tooltip = "Target to pursue.")]
    GameObjectVar targetVar;

    public override void Reset()
    {
        targetVar = blackboard.GetGameObjectVar("Target");
    }

    public override Status Update()
    {
        if (targetVar == null || targetVar.Value == null)
        {
            return Status.Failure;
        }
        else
        {
            if (Vector3.Distance(owner.root.transform.position, targetVar.Value.transform.position) <= attackRange)
            {
                Debug.Log("Attack");
                return Status.Success;
            }
        }

        return Status.Failure;
    }
}
