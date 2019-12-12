using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public SpriteRenderer buttonPrompt;
    public Animator animator;
    public bool isExit;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        buttonPrompt.enabled = true;
        animator.SetBool("isExit", isExit);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        float interact = Input.GetAxisRaw("Interact");
        if (Mathf.Approximately(interact, 1))
        {
            TriggerDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        buttonPrompt.enabled = false;
    }
}
