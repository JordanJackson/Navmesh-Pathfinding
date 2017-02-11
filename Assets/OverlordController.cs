using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlordController : MonoBehaviour 
{
    Button[] unitButtons;
    public Unit[] units;
    public int defaultSelection = 0;
    public int currentSelection;
    public Slider manaSlider;
    public float currentMana;
    public float maxMana;
    public float manaPortionStart;
    // this should depend on intact buildings, game duration etc.
    public float manaRate;

    Canvas canvas;
    GameObject unitSelectPanel;
    GameObject manaPanel;
    public GameObject unitSelectPanelPrefab;
    public GameObject manaPanelPrefab;
    // Overlord class should not manage UI

    void Awake()
    {
        // get Canvas
        canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            // consider spawning Canvas as well
            Debug.LogError("No Canvas");
        }
        // instantiate unitSelectPanel
        unitSelectPanel = Instantiate(unitSelectPanelPrefab, canvas.transform, false) as GameObject;
        // get reference to buttons
        unitButtons = unitSelectPanel.GetComponentsInChildren<Button>();
        // instantiate manaPanel
        manaPanel = Instantiate(manaPanelPrefab, canvas.transform, false) as GameObject;
        // set reference to manaSlider
        manaSlider = manaPanel.GetComponentInChildren<Slider>();
        manaSlider.minValue = 0;
        manaSlider.maxValue = maxMana;
        currentMana = maxMana * manaPortionStart;
        manaSlider.value = currentMana;
    }

    private void Start()
    {
        currentSelection = defaultSelection;
    }

    private void Update()
    {
        UpdateMana();
        HandleMouseInput();
    }

    void UpdateMana()
    {
        currentMana += manaRate * Time.deltaTime;
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // create a Raycast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                SpawnUnit(hit.point);
            }
        }
    }

    void SpawnUnit(Vector3 point)
    {
        Unit u = units[currentSelection];
        if (u.cost <= currentMana)
        {
            currentMana -= u.cost;
            Instantiate(u, point + u.spawnOffset, Quaternion.identity);
        }
        
    }

    void OnGUI()
    {
        HandleGUIInput();
        UpdateUnitSelectionPanels();
        UpdateManaPanel();
    }

    void HandleGUIInput()
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
    }

    void UpdateUnitSelectionPanels()
    {
        for (int i = 0; i < unitButtons.Length; i++)
        {
            if (i != currentSelection)
            {
                unitButtons[i].GetComponent<Image>().color = Color.grey;
            }
        }
        unitButtons[currentSelection].GetComponent<Image>().color = Color.white;
    }
    
    void UpdateManaPanel()
    {
        manaSlider.value = currentMana;
    }
}
