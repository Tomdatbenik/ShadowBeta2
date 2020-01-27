using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToOtherScene : MonoBehaviour
{
    public int transportScene;
    public SpriteRenderer buttonPrompt;
    public Animator animator;
    public bool isExit;
    public bool hasNoCollider;
    public Quest quest;
    public int index;

    public PlayerSpawnLocation spawnLocation;

    public Spawn Spawn;

    private void Start()
    {
        if (isExit)
        {
            animator.SetBool("isExit", isExit);
        }
    }

    private void Update()
    {
        if(hasNoCollider)
        {
            keyPressed();
        }
    }

    private void keyPressed()
    {
        if(quest == null)
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
        else if(quest.QuestState == QuestState.COMPLETED || quest.QuestState == QuestState.ENDED)
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
        if (quest != null)
        {
            if (quest.QuestState == QuestState.COMPLETED || quest.QuestState == QuestState.ENDED)
            {
                buttonPrompt.enabled = true;
            }
        }
        else
        {
            buttonPrompt.enabled = true;
        }

        animator.SetBool("isExit", isExit);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        keyPressed();
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
        if(!spawnIsNull())
            spawnLocation.spawn = Spawn;
        SceneManager.LoadScene(transportScene);
    }

    private bool spawnIsNull()
    {
        if (Spawn == null)
            return true;
        return false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        buttonPrompt.enabled = false;
    }
}
