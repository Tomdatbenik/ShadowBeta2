﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public AudioSource audioSource;
    [SerializeField] public AudioClip[] audioClips;
    public static bool talking;
    
    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
       animator.SetBool("isOpen", true);
       sentences.Clear();
       talking = true;

       foreach (string sentence in dialogue.sentences)
       {
           sentences.Enqueue(sentence);
       }

       DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            talking = false;
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            PlayDialogueAudio();
            yield return null;
        }
    }

    private void EndDialog()
    {
        animator.SetBool("isOpen", false);
    }

    private void PlayDialogueAudio()
    {
        if (!audioSource.isPlaying)
        {
            float pitch = Random.Range(0.5f, 1.5f);
            int n = Random.Range(1, audioClips.Length);
            audioSource.clip = audioClips[n];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioSource.clip);
            audioClips[n] = audioClips[0];
            audioClips[0] = audioSource.clip;
        }
    }
}