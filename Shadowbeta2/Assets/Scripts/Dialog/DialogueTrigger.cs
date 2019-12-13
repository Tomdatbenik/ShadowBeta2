using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public SpriteRenderer buttonPrompt;
    public Animator animator;

    public TeacherWalk teacherWalk;

    private DialogueManager dialoguemanager;

    private void Start()
    {
        dialoguemanager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        dialoguemanager.StartDialogue(dialogue);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        teacherWalk.IsWalking = false;
        buttonPrompt.enabled = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        buttonPrompt.enabled = true;
        if (Input.GetButton("Interact"))
        {
            TriggerDialogue();  
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        teacherWalk.IsWalking = true;
        buttonPrompt.enabled = false;
        dialoguemanager.EndDialog();
    }
}
