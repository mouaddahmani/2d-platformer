using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uimanager : MonoBehaviour
{
    public List<GameObject> playUi = new List<GameObject>();
    public List<GameObject> gameOverUi = new List<GameObject>();

    public void setPlayButtons(bool mode)
    {
        foreach (GameObject element in playUi)
        {
            element.SetActive(mode);
        }
    }

    public void setGameOverbuttons(bool mode)
    {
        foreach (GameObject element in gameOverUi)
        {
            element.SetActive(mode);
        }
    }
}
