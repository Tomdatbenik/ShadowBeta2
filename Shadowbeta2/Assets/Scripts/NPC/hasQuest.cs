using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasQuest : MonoBehaviour
{
    public Quest quest;
    public SpriteRenderer mark;

    public Sprite HasQuest;
    public Sprite QuestComplete;
    public Sprite AcceptedQuest;

    private void Start()
    {
        if(quest != null)
        {
            mark.sprite = HasQuest;
        }
    }

    private void Update()
    {
        if(quest.QuestState == QuestState.COMPLETED)
        {
            mark.sprite = QuestComplete;
        }

        if(quest.QuestState == QuestState.ASSIGNED)
        {
            mark.sprite = AcceptedQuest;
        }
    }
}
