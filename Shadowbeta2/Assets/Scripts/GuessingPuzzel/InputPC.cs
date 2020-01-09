using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPC : MonoBehaviour
{
    public TMP_InputField inputText;
    int score = 0;
    
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            string input = inputText.text;
            if(input.Contains("Jimmy"))
            {
                score++;
            }
            if(input.Contains("2018"))
            {
                score++;
            }

        }
    }
}
