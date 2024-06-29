using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject RawImage; // Assign the minimap GameObject in the Inspector
    private bool isMinimized = false;

    public void ToggleMinimap()
    {
        isMinimized = !isMinimized;
        RawImage.SetActive(!isMinimized);
    }
}
