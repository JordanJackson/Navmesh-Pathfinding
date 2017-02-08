using BehaviourMachine;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ApproachActionNode : ActionNode 
{

    public override Status Update()
    {
        Debug.Log("Approach Update");
        return Status.Success;
    }
}
