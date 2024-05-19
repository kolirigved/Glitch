using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image bar;

    private void Start()
    {
        bar = GetComponent<Image>();
    }

    private void Update()
    {
        if(bar.fillAmount >= 0.5f)
        {
            bar.color = Color.green;
        }
        else if(bar.fillAmount >= 0.2f)
        {
            bar.color = Color.yellow;
        }
        else
        {
            bar.color = Color.red;
        }
        if(bar.fillAmount <= 0)
        {
            SceneManager.LoadScene("LostScreen");
        }
    }
}
