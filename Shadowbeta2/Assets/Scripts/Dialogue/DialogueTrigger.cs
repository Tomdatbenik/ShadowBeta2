using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private DialogueManager dialoguemanager;

    private void Start()
    {
        dialoguemanager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        dialoguemanager.StartDialogue(dialogue);
    }

    public void EnemyDamageDialogue()
    {
        
        dialogue = new Dialogue(new string[] {"You won the clash with the enemy", "The enemy takes 1 damage"});
        TriggerDialogue();
    }
    
    public void HeroDamageDialogue()
    {
        dialogue = new Dialogue(new string[] {"You Lost the clash with the enemy", "You take 1 damage"});
        TriggerDialogue();
    }
    
    public void EnemyWonDialogue()
    {
        dialogue = new Dialogue(new string[] {"You Lost the battle with the enemy", "Better luck next time pleb."});
        TriggerDialogue();
    }
    
    public void HeroWonDialogue()
    {
        dialogue = new Dialogue(new string[] {"You won the battle with the enemy", "GG no re, Ez Pz "});
        TriggerDialogue();
    }
    
    public void DrawDialogue()
    {
        dialogue = new Dialogue(new string[] {"You both are so strong! it became a draw!", "You both take 1 damage each!"});
        TriggerDialogue();
    }
    
    public void BothLostDialogue()
    {
        buttonPrompt.enabled = false;
        dialoguemanager.EndDialog();

    }
}
