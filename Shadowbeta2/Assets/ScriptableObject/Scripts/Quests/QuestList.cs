using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class QuestList : ScriptableObject
{
    public List<Quest> Quests;

    public List<Quest> GetQuestsState(QuestState state)
    {
        List<Quest> ReturnList = new List<Quest>();
     
        FillListOnState(state, ReturnList);

        return ReturnList;
    }

    private void FillListOnState(QuestState state, List<Quest> quests)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.QuestState == state)
            {
                quests.Add(quest);
            }
        }
    }

}
