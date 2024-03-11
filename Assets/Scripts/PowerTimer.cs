using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerTimer : MonoBehaviour
{
    public float RefillTime = 40f;
    public Image timer;
    public float effectTime = 3f;
    float effectTimer = 0f;

    private void Start()
    {
        timer = GetComponent<Image>();
        timer.fillAmount = 1;
    }
    private void Update()
    {
        effectTimer-= Time.deltaTime/Time.timeScale;
        if(effectTimer < 0 && Time.timeScale!=0)
        {
            Time.timeScale = 1;
        }
        timer.fillAmount += (1 / RefillTime)*Time.deltaTime/Time.timeScale;
    }

    public void PowerUp(float TimeFactor)
    {
        Time.timeScale = TimeFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        timer.fillAmount = 0;
        effectTimer = effectTime;
    }
}
