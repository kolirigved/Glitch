using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWallIdentifier : MonoBehaviour
{
    public float rotation;
    GameObject rotator;

    private void Start()
    {
        rotator = GameObject.FindGameObjectWithTag("Rotator");
    }
    private void Update()
    {
        if (rotator.transform.rotation.eulerAngles.z == rotation || rotator.transform.rotation.eulerAngles.z == rotation - 360)
        {
            gameObject.tag = "Ground";
        }
        else
        {
            gameObject.tag = "wall";
        }
    }
}
