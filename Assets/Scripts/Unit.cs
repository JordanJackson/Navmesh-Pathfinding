using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Unit : MonoBehaviour
{
    public int cost;
    public Vector3 spawnOffset;
    // TODO: consider storing things like health, name, thumbnail etc.
    // TODO: consider have a ready time to delay activation
    public abstract void Attack();
	
}
