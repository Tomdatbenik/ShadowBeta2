using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int time;
    public int rate;
    public List<GameObject>lighting;

    private bool active = true;

    void Update()
    {
        Debug.Log(time);
        if(time > rate)
        {
            int r = Random.Range(0, 101);
            
            active = true;
  
            if(r > 50)
            {
                if (!lighting[0].activeSelf)
                {
                    lighting[0].SetActive(active);
                }
            }
            else
            {
                if (!lighting[1].activeSelf)
                {
                    lighting[1].SetActive(active);
                }
            }
            time = 0;
        }
        else
        {

            active = false;
            if (lighting[0].activeSelf)
            {
                lighting[0].SetActive(active);
            }

            if (lighting[1].activeSelf)
            {
                lighting[1].SetActive(active);
            }
        }

        time++;


    }
}
