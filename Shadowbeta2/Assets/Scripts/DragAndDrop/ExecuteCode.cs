using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExecuteCode : MonoBehaviour
{
    public GameObject[] answerBoxes;

    private int enteredAllAnswers = 0;
    private int wrongAnswers = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClick()
    {
        Debug.Log("clicked on button");
        foreach (GameObject answerBox in answerBoxes)
        {
            if (answerBox.transform.childCount != 0)
            {
                enteredAllAnswers++;
            }
        }
        if (enteredAllAnswers == answerBoxes.Length)
        {
            foreach (GameObject answerBox in answerBoxes)
            {
                //Gets DragAndDrop script of the answerbox
                DragAndDrop controlScript = answerBox.transform.GetChild(0).GetComponent<DragAndDrop>();
                if (controlScript.answerObject != answerBox)
                {
                    wrongAnswers++;
                    controlScript.GetComponent<Transform>().GetChild(0).GetComponent<TextMeshPro>().color = Color.red;
                }
                else
                {
                    controlScript.GetComponent<Transform>().GetChild(0).GetComponent<TextMeshPro>().color = Color.green;
                }
            }
            Debug.Log("wrong answers: " + wrongAnswers);
        }
        else
        {
            Debug.Log("Not all answers answered");
        }
        enteredAllAnswers = 0;
        wrongAnswers = 0;
    }
}
