using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceRandom : MonoBehaviour
{

    public int Chance;
    private bool flipped;

    // Update is called once per frame
    void Update()
    {
        int r = Random.Range(0, 101);
        if (Chance < r)
        {
            flip();
        }
    }

    private void flip()
    {
        if(flipped)
        {
            flipped = false;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        else
        {
            flipped = true;
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 1);
        }
    }
}
