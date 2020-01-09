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
    public bool hasNoCollider;
    public Spawnloaction GoToLocation;

    private void Start()
    {
        if(isExit)
        {
            animator.SetBool("isExit", isExit);
        }
    }

    private void Update()
    {
        if(hasNoCollider)
        {
            if (isExit)
            {
                if (isExitPressed())
                {
                    goToScene();
                }
            }
            else
            {
                if (isInteractPressed())
                {
                    goToScene();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        buttonPrompt.enabled = true;
        animator.SetBool("isExit", isExit);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(isExit)
        {
            if(isExitPressed())
            {
                goToScene();
            }
        }
        else
        {
            if (isInteractPressed())
            {
                goToScene();
            }
        }
    }

    private bool isExitPressed()
    {
        float exit = Input.GetAxis("Cancel");
        if (Mathf.Approximately(exit, 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool isInteractPressed()
    {
        float interact = Input.GetAxisRaw("Interact");
        if (Mathf.Approximately(interact, 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void goToScene()
    {
        DataManager.lastLocation = GoToLocation;
        SceneManager.LoadScene(transportScene.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        buttonPrompt.enabled = false;
    }
}
