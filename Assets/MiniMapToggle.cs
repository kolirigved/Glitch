using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapToggle : MonoBehaviour
{
    public GameObject RawImage; // Assign the minimap GameObject in the Inspector
    private bool isMinimized = false;

    void Update()
    {
        // Check if the "M" key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMinimap();
        }
    }
    public void ToggleMinimap()
    {
        isMinimized = !isMinimized;
        RawImage.SetActive(isMinimized);
    }
}
