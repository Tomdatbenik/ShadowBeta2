using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    #region public variables
    /// <summary>
    /// Diaglog ui
    /// </summary>
    public Conversation conversation;

    /// <summary>
    /// Dialog animator
    /// </summary>
    public Animator animator;

    public GameObject Button;

    public TeacherWalk teacherWalk;

    public bool canTalk;
    #endregion

    #region private variables
    /// <summary>
    /// Player button sprite renderen
    /// </summary>
    private SpriteRenderer ButtonSpriteRenderen;

    /// <summary>
    /// Dialoguemanager
    /// </summary>
    private DialogueManager dialoguemanager;

    #endregion

    private void Start()
    {
        setDialogueManager();
        setButtonRenderer();
    }

    private void setDialogueManager()
    {
        dialoguemanager = FindObjectOfType<DialogueManager>();
    }

    private void setButtonRenderer()
    {
        ButtonSpriteRenderen = Button.GetComponent<SpriteRenderer>();
    }

    public void TriggerDialogue()
    {
        dialoguemanager.StartDialogue(conversation);
    }

    private void endDiaglogue()
    {
        conversation.NextTopic();

        dialoguemanager.EndDialog();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(canTalk)
        {
            setWalking(false);
            showButton();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(canTalk)
        {
            showButton();
            if (isTalking())
                TriggerDialogue();
        }
    }

    private void showButton()
    {
        ButtonSpriteRenderen.enabled = true;
    }

    private void hideButton()
    {
        ButtonSpriteRenderen.enabled = false;
    }

    private bool isTalking()
    {
        float interact = Input.GetAxisRaw("Interact");
        if (Mathf.Approximately(interact, 1))
            return true;
        return false;
    }

    private void setWalking(bool walking)
    {
        teacherWalk.IsWalking = walking;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(canTalk)
        {
            setWalking(true);
            hideButton();
            endDiaglogue();
        }
    }
}
