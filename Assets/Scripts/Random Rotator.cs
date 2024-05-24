using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    //[SerializeField] float changeInterval = 10f;
    [SerializeField] float Timer;
    [SerializeField] float RotateSpeed = 1f;
    [SerializeField] float minChangeInterval = 3f;
    [SerializeField] float maxChangeInterval = 10f;
    float changeTime = 0;
    int mode = 0;
    float changeTimer;
    Quaternion OldRotation = Quaternion.identity;
    void Start()
    {
        Timer = Random.Range(8,15);
        changeTimer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        changeTimer += Time.deltaTime;
        if (Timer < 0)
        {
            int newmode = Random.Range(0, 4);
            while (mode == newmode)
            {
                newmode = Random.Range(0, 4);
            }
            mode = newmode;
            Timer = Random.Range(minChangeInterval, maxChangeInterval);
            OldRotation = transform.rotation;
            changeTime = Mathf.Abs(Target(mode).eulerAngles.z - OldRotation.eulerAngles.z) / RotateSpeed;
            changeTimer = 0;
        }
        if (changeTimer < changeTime)
        {
            Quaternion Rotation = Quaternion.identity;
            Rotation.eulerAngles = new Vector3(0, 0, OldRotation.eulerAngles.z + RotateSpeed * changeTimer);
            transform.rotation = Rotation;
            //Debug.Log(RotateSpeed);
        }
        else
        {
            transform.rotation = Target(mode);
        }

    }

    Quaternion Target(float mode)
    {
        Quaternion value = Quaternion.identity;
        switch (mode)
        {
            case 0: value.eulerAngles = new Vector3(0, 0, 0); break;
            case 1: value.eulerAngles = new Vector3(0, 0, 90); break;
            case 2: value.eulerAngles = new Vector3(0, 0, 180); break;
            case 3: value.eulerAngles = new Vector3(0, 0, 270); break;
        }
        return value;
    }
}
