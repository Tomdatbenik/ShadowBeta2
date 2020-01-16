using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Conversation : ScriptableObject
{
    public int topicIndex = 0;
    public List<Topic> topics;
    public Quest Quest;

    public string Talker;

    public void NextTopic()
    {
        if (canGoToNextTopic())
        {
            topicIndex++;
        }
    }

    private int getTopicIndex(Topic topic)
    {
        int TIndex = 0;
        foreach(Topic t in topics)
        {
            if(t == topic)
            {
                return TIndex;
            }

            TIndex++;
        }

        return 0;
    }

    private int getPostTopicIndex()
    {
        int TIndex = 0;
        foreach (Topic t in topics)
        {
            if (isPostQuestTopic(t))
            {
                return TIndex;
            }

            TIndex++;
        }

        return 0;
    }

    public Topic GetTopic()
    {
        Topic topic = topics[topicIndex];

        if(Quest.QuestState == QuestState.COMPLETED)
        {
            int posttopicindex = getPostTopicIndex();
            if (getTopicIndex(topic) < posttopicindex)
            {
                topicIndex = posttopicindex;
                return topics[topicIndex];
            }
        }

        if (isPostQuestTopic(topic))
        {
            //Maybe assign score or something
        }
        else if (isAssignmentTopic(topic))
        {
            if (((AssignmentTopic)topic).assign)
            {
                Quest.QuestState = QuestState.ASSIGNED;
            }           
        }

        return topic;
    }

    private int topicCount()
    {
        return (topics.Count - 1);
    }

    private bool canGoToNextTopic()
    {
        if (topicIndex < topicCount())
        {
            Topic nexttopic = topics[topicIndex + 1];
            if (isPostQuestTopic(nexttopic))
            {
                if(Quest.QuestState != QuestState.COMPLETED)
                {
                    return false;
                }

                return true;
      
            }
            else
            {
                return true;
            }
           
        }

        return false;
    }

    private bool isPostQuestTopic(Topic topic)
    {
        return topic.GetType() == typeof(PostQuestTopic);
    }

    private bool isAssignmentTopic(Topic topic)
    {
        return topic.GetType() == typeof(AssignmentTopic);
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        UnityEditor.EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
    }

    private void OnDisable()
    {
        UnityEditor.EditorApplication.playModeStateChanged -= EditorApplication_playModeStateChanged;
    }

    private void EditorApplication_playModeStateChanged(UnityEditor.PlayModeStateChange state)
    {
        if (state == UnityEditor.PlayModeStateChange.EnteredEditMode)
        {
            topicIndex = 0;
        }
    }
#endif
}
