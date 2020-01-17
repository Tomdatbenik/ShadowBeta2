using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject QuestGameobject;
    public QuestList QuestList;
    public GameObject content;
    public QuestButton QuestButton;

    public List<GameObject> Quests;

    public void LoadQuests()
    {
        foreach(GameObject @object in Quests)
        {
            Destroy(@object);
        }

        if(QuestButton.opened)
        {
            foreach (Quest quest in QuestList.GetQuestsByState(QuestState.UNASSIGNED))
            {
                setQuest(quest);
            }

            foreach (Quest quest in QuestList.GetQuestsByState(QuestState.ASSIGNED))
            {
                setQuest(quest);
            }

            foreach (Quest quest in QuestList.GetQuestsByState(QuestState.COMPLETED))
            {
                setQuest(quest);
            }
        }
    }

    private void setQuest(Quest quest)
    {
        GameObject @object = Instantiate(QuestGameobject, content.transform);
        Quests.Add(@object);

        LoadQuest loadQuest = QuestGameobject.GetComponent<LoadQuest>();
        loadQuest.quest = quest;
    }

    private void Update()
    {
        LoadQuests();
    }
}
