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
            mark.gameObject.SetActive(true);
            mark.sprite = HasQuest;
        }
        else
        {
            mark.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(quest != null)
        {
            if (quest.QuestState == QuestState.COMPLETED)
            {
                mark.sprite = QuestComplete;
            }

            if (quest.QuestState == QuestState.ASSIGNED)
            {
                mark.sprite = AcceptedQuest;
            }
        }
       
    }
}
