using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPC : MonoBehaviour
{
    public TMP_InputField inputText;
    public LaunchConfetti launchConfetti;
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
            if(score == 2)
            {
                launchConfetti.ShootConfetti();
            }
            Debug.Log(score);
        }
    }
}
