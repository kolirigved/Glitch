 using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomGravitizer : MonoBehaviour
{
    [SerializeField] float changeInterval = 10f;
    [SerializeField] float Timer;
    [SerializeField] float changeTime = 2f;
    Vector2 New;
    Vector2 Old;
    float changeTimer ;
    public int mode = 0;
    // Update is called once per frame
    private void Start()
    {
        Timer = changeInterval;
        changeTimer = changeTime;
    }
    void Update()
    {
        Timer -= Time.deltaTime;
        changeTimer += Time.deltaTime;
        if (Timer < 0)
        {
            Old = Physics2D.gravity;
            int newmode = Random.Range(0, 4);
            while(mode == newmode) {
                newmode = Random.Range(0, 4);
             }
            mode = newmode;
            New = Changer(mode);
            Timer = changeInterval;
            changeTimer = 0;
        }
        if(changeTimer < changeTime)
        {
            float x;
            float y;
            if (New == -1 * Old)
            {
                Vector2 Intermediate = Changer((mode + 1) % 4);
                if (changeTimer < changeTime / 2)
                {
                    x = 2*(Intermediate.x - Old.x)/changeTime;
                    y = 2 * (Intermediate.y - Old.y) / changeTime;
                }
                else
                {
                    x = 2*(New.x - Old.x) / changeTime;
                    y = 2*(New.y - Old.y) / changeTime;
                }
            }
            else
            {
                 x = (New.x - Old.x) / changeTime;
                 y = (New.y - Old.y) / changeTime;
            }
                Physics2D.gravity = new Vector2(Old.x + x * changeTimer, Old.y + y * changeTimer);
        }
    }

    Vector2 Changer(float mode)
    {
        Vector2 value = Vector2.zero;
        switch (mode)
        {
            case 0: 
                 value = new Vector2(0, -9.81f);
                break;
            case 1:
                 value = new Vector2(-9.81f, 0);
                break;
            case 2:
                 value = new Vector2(0, 9.81f);
                break;
            case 3:
                 value = new Vector2(9.81f,0);
                break;
        }
        return value;
    }
}
