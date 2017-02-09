using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlordController : MonoBehaviour 
{
    public Button[] unitButtons;
    public int defaultSelection = 0;
    public int currentSelection;

    private void Start()
    {
        currentSelection = defaultSelection;
    }

    private void Update()
    {
        
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey)
        {
            // convert Alpha# to int
            int keyToID = (int)e.keyCode - 49;
            // if valid unit selection
            if (keyToID >= 0 && keyToID < unitButtons.Length)
            {
                currentSelection = keyToID;
            }
        }

        for (int i = 0; i < unitButtons.Length; i++)
        {
            if (i != currentSelection)
            {
                unitButtons[i].GetComponent<Image>().color = Color.grey;
            }
        }
        unitButtons[currentSelection].GetComponent<Image>().color = Color.white;
    }

     
}
