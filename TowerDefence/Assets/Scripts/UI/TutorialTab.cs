using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTab : MonoBehaviour
{
    public List<GameObject> chronologicalPanels = new List<GameObject>();

    public Button backButton;
    public Button forwardButton;

    private int activePanelIndex = 0;

    void Start()
    {
        ShowGivenPanel(activePanelIndex);

        EnableDisableButtons();
    }

    private void ShowGivenPanel(int listIndex)
    {
        foreach (GameObject panel in chronologicalPanels)
        {
            panel.SetActive(false);
        }

        chronologicalPanels[listIndex].SetActive(true);
    }

    public void IncrementActivePanel()
    {
        if (activePanelIndex >= chronologicalPanels.Count - 1)
        {
            activePanelIndex = chronologicalPanels.Count - 1;
            return;
        }

        activePanelIndex++;

        ShowGivenPanel(activePanelIndex);

        EnableDisableButtons();
    }

    public void DecrementActivePanel()
    {
        if (activePanelIndex <= 0)
        {
            activePanelIndex = 0;
            return;
        }

        activePanelIndex--;

        ShowGivenPanel(activePanelIndex);

        EnableDisableButtons();
    }

    private void EnableDisableButtons()
    {
        if (activePanelIndex <= 0)
        {
            forwardButton.gameObject.SetActive(true);
            backButton.gameObject.SetActive(false);
            return;
        }
        
        if (activePanelIndex >= chronologicalPanels.Count - 1)
        {
            forwardButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(true);
            return;
        }

        else
        {
            forwardButton.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
        }
    }
}
