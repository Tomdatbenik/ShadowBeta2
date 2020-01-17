using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    public bool CanTalk;
    public Quest quest;
    public GameObject dialog;
    public DialogueTrigger dialogueTrigger;
    private void Start()
    {
        setTalking();
    }

    private void Update()
    {
        setTalking();
    }

    private void setTalking()
    {
        if (quest.QuestState != QuestState.COMPLETED)
        {
            dialogueTrigger.canTalk = CanTalk;
        }
        else
        {
            dialogueTrigger.canTalk = false;
        }
    }

}
