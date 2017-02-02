using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

[NodeInfo(category = "Condition/Enemy/", icon = "DefaultAsset", description = "Detect Target")]
public class DetectTarget : ConditionNode
{

    [VariableInfo(requiredField = true, tooltip = "Detection radius")]
    public FloatVar detectionRadius;

    public override void Reset()
    {
        
    }

    public override Status Update()
    {
        // create temp array and list
        List<Player> closePlayers = new List<Player>();
        Player[] players = GameObject.FindObjectsOfType<Player>();

        if (players.Length >= 0)
        {
            // find all players in detection radius
            foreach (Player p in players)
            {
                if (Vector3.Distance(p.transform.position, owner.root.transform.position) <= detectionRadius)
                {
                    closePlayers.Add(p);
                }
            }
            // if no close players, fail
            if (closePlayers.Count <= 0)
            {
                return Status.Failure;
            }
            else
            {
                Player closest = null;
                float closestDistance = float.MaxValue;

                foreach (Player p in closePlayers)
                {
                    float d = Vector3.Distance(p.transform.position, owner.root.transform.position);
                    if (d <= closestDistance)
                    {
                        closest = p;
                        closestDistance = d;
                    }
                }

                if (closest == null)
                {
                    return Status.Failure;
                }
                else
                {
                    blackboard.GetGameObjectVar("Target").Value = closest.gameObject;
                    return Status.Success;
                }
            }
        }
        else
        {
            return Status.Failure;
        }
    }
}
