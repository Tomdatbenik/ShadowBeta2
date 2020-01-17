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
    public Sprite EndedQuest;

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
            switch(quest.QuestState)
            {
                case QuestState.COMPLETED:
                    mark.sprite = QuestComplete;
                    break;
                case QuestState.ASSIGNED:
                    mark.sprite = AcceptedQuest;
                    break;
                case QuestState.UNASSIGNED:
                    mark.sprite = HasQuest;
                    break;
                case QuestState.ENDED:
                    mark.sprite = EndedQuest;
                    break;
            }
        }
    }
}
