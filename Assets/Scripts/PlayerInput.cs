using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{

    Player p;

    private void Start()
    {
        p = this.GetComponent<Player>();
    }

    private void Update()
    {
        if (p != null)
        {
            HandleInput();
        }

    }

    void HandleInput()
    {
        Vector2 inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        p.Movement(inputs);
    }
}
