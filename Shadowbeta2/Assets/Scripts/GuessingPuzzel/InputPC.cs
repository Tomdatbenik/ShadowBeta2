using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPC : MonoBehaviour
{
    public TMP_InputField inputText;
    int score = 0;
    public string[] good_answers;

   

    // Update is called once per frame
    void Update()
    {
        inputText.Select();
        if(Input.GetKeyDown(KeyCode.Return))
        {
            score = 0;
            string input = inputText.text;
            foreach(string answer in good_answers)
            {
                if(input.Contains(answer))
                {
                    score++;
                }
            }
            Debug.Log(score);
        }
    }
}
