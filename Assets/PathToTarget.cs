using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using System;

[NodeInfo(category = "Action/Transform/",
    icon = "Transform",
    description = "Calculates the path to a target, sets the path and follows it.")]
public class PathToTarget : ActionNode 
{

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void Reset()
    {
        base.Reset();
    }

    public override Status Update()
    {
        return Status.Running;
    }
}
