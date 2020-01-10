﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputPC : MonoBehaviour
{
    public TMP_InputField inputText;
    public 
    public LaunchConfetti launchConfetti;
    int score = 0;
    public string[] good_answers;
    
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
            if(score != 0)
            {
                launchConfetti.ShootConfetti();
            }
            if(score == 0)
            {

            }
            Debug.Log(score);
        }
    }
}
