using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AbilityPanel : MonoBehaviour
{
    public GameObject[] panels;
    public Button[] buttons;
    private GameObject currentPanel;

    private void Start()
    {
        currentPanel = panels[0];

    }
    public void swapPanel(int desiredPanel)
    {
        if (desiredPanel == panels.Length - 1)
        {
            currentPanel.SetActive(false);
            panels[desiredPanel].SetActive(true);
        }
    }

    public void back()
    {
        foreach (var panel in panels) 
        {
            panel.SetActive(false);
        }
        currentPanel = panels[0];
        currentPanel.SetActive(true);
    }
}
