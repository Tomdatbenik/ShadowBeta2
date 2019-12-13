using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI InteractableName;
    public Animator animator;
    public AudioSource audioSource;
    [SerializeField] public AudioClip[] audioClips;
    public SpriteRenderer buttonPrompt;
    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        checkNextSentence();
    }

    private void checkNextSentence()
    {
        if (Input.GetKeyDown("space"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
       buttonPrompt.enabled = false;
       InteractableName.text = dialogue.interactableName;
       animator.SetBool("isOpen", true);
       sentences.Clear();

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
            if (Input.GetKeyDown("space"))
            {
                EndDialog();
                return;
            }
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

    public void EndDialog()
    {
        buttonPrompt.enabled = true;
        animator.SetBool("isOpen", false);
    }

    private void PlayDialogueAudio()
    {
        if (!audioSource.isPlaying)
        {
            int n = Random.Range(1, audioClips.Length);
            audioSource.clip = audioClips[n];
            audioSource.PlayOneShot(audioSource.clip);
            audioClips[n] = audioClips[0];
            audioClips[0] = audioSource.clip;
        }
    }
}
