using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    public bool CanTalk;
    public GameObject dialog;

    private void Start()
    {
        if(CanTalk)
        {
            dialog.SetActive(true);
        }
        else
        {
            dialog.SetActive(false);
        }
    }
}
