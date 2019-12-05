using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToOtherScene : MonoBehaviour
{
    public Object transportScene;

    void OnTriggerStay2D(Collider2D other)
    {
        float interact = Input.GetAxisRaw("Interact");
        if (Mathf.Approximately(interact, 1))
        {
            SceneManager.LoadScene(transportScene.name);
        }
    }
}
