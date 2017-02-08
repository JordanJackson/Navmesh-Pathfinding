using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlordController : MonoBehaviour 
{
    public Button[] unitButtons;
    public int defaultSelection = 0;
    int currentSelection;

    private void Start()
    {
        currentSelection = defaultSelection;
    }

    private void Update()
    {
        unitButtons[currentSelection].GetComponent<Image>().color = Color.green;

        Event e = Event.current;

        if (Input.anyKeyDown && e.isKey)
        {
            
        }
    }

     
}
