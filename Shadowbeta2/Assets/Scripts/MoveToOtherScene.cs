using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToOtherScene : MonoBehaviour
{
    public Object transportScene;
    public SpriteRenderer buttonPrompt;
    public Animator animator;
    public bool isExit;

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
            SceneManager.LoadScene(transportScene.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        buttonPrompt.enabled = false;
    }
}
