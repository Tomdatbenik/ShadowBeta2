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
    public Dialogue dialogue;

    /// <summary>
    /// Dialog animator
    /// </summary>
    public Animator animator;

    public GameObject Button;

    public TeacherWalk teacherWalk;
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
        dialoguemanager = FindObjectOfType<DialogueManager>();

        ButtonSpriteRenderen = Button.GetComponent<SpriteRenderer>();
    }

    public void TriggerDialogue()
    {
        dialoguemanager.StartDialogue(dialogue);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        teacherWalk.IsWalking = false;
        ButtonSpriteRenderen.enabled = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ButtonSpriteRenderen.enabled = true;
        float interact = Input.GetAxisRaw("Interact");

        if(Mathf.Approximately(interact,1))
        {
            TriggerDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        teacherWalk.IsWalking = true;
        ButtonSpriteRenderen.enabled = false;
        dialoguemanager.EndDialog();
    }
}
