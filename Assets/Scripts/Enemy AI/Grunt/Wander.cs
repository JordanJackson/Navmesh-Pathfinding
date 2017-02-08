using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourMachine;

[NodeInfo(category = "Action/Enemy/", icon = "DefaultAsset", description = "Wander around.")]
public class Wander : ActionNode {

    public float wanderRadius;
    public float wanderTime;
    float timer;

    NavMeshAgent agent;

    public override void Reset()
    {
        timer = wanderTime;
        agent = owner.root.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent is null.");
        }
    }

    public override Status Update()
    {

        timer += Time.deltaTime;

        if (timer >= wanderTime)
        {
            Vector3 wanderPos = RandomNavSphere(owner.root.transform.position, wanderRadius);
            agent.SetDestination(wanderPos);
            timer = 0;
            NavMeshPath path = new UnityEngine.AI.NavMeshPath();

            bool success = agent.CalculatePath(wanderPos, path);
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

        return Status.Success;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randDirection, out navHit, dist, NavMesh.AllAreas))
        {
            return navHit.position;
        }
        else
        {
            return Vector3.zero;
        }

        
    }
}
