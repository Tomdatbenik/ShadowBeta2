using System.Collections;
using System.Collections.Generic;
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
                if (controlScript.AnswerObject != answerBox)
                {
                    wrongAnswers++;
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
