using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour 
{

    NavMeshAgent agent;

    Player player;

    NavMeshPath currentPath;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        currentPath = new NavMeshPath();
    }

    void Update()
    {
        // agent and player target valid
        if (agent != null && player != null)
        {
            // calculate path
            if (agent.CalculatePath(player.transform.position, currentPath))
            {
                agent.SetPath(currentPath);
            }
        }
        else
        {
            Debug.LogWarning("Agent or Player null.");
        }
    }

    void OnDrawGizmos()
    {
        if (currentPath != null)
        {
            for (int i = 0; i < currentPath.corners.Length; i++)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawCube(currentPath.corners[i], Vector3.one);
                if (i < currentPath.corners.Length - 1)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawLine(currentPath.corners[i], currentPath.corners[i + 1]);
                }
            }
        }
        
    }
}
