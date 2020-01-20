using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public Quiz quiz;
    public Animator Animator;
    public GameObject Button;
    
    private QuizManager _quizManager;
    private SpriteRenderer ButtonSpriteRenderen;
    
    private void Start()
    {
        setQuizManager();
        setButtonRenderer();

    }
    private void setButtonRenderer()
    {
        ButtonSpriteRenderen = Button.GetComponent<SpriteRenderer>();
    }

    private void setQuizManager()
    {
        _quizManager = FindObjectOfType<QuizManager>();
    }
    
    public void TriggerQuiz()
    {
      _quizManager.StartQuiz(quiz);
    }

    private void OnTriggerStay(Collider other)
    {
        showButton();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        showButton();
    }
        
    void OnTriggerExit2D(Collider2D other)
    {

        hideButton();

    }

    private void showButton()
    {
        ButtonSpriteRenderen.enabled = true;
        Debug.Log("Collided");
    }

    private void hideButton()
    {
        ButtonSpriteRenderen.enabled = false;
    }
    
}
