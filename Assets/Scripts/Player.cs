using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{

    public float moveSpeed;

	public void Movement(Vector2 inputs)
    {
        this.transform.Translate(Vector3.Normalize(this.transform.forward * inputs.y + this.transform.right * inputs.x) * Time.deltaTime * moveSpeed);
    }
}
