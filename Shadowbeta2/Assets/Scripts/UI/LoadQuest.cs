using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadQuest : MonoBehaviour
{
    public Quest quest;

    public Image mark; 
    public TextMeshProUGUI text;

    public Sprite HasQuest;
    public Sprite AcceptedQuest;
    public Sprite QuestComplete;
    public Sprite EndedQuest;

    private void Start()
    {

        text.text = quest.name;

        switch (quest.QuestState)
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
