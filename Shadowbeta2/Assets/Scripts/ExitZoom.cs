using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitZoom : MonoBehaviour
{
    public Object sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        float exit = Input.GetAxis("Cancel");
        if (Mathf.Approximately(exit, 1))
        {
            SceneManager.LoadScene(sceneToLoad.name);
        }
    }
}
