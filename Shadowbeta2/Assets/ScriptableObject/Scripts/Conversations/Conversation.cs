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

    public Topic GetTopic()
    {
        return topics[topicIndex];
    }

    private int topicCount()
    {
        return topics.Count;
    }

    private bool canGoToNextTopic()
    {
        if (topicIndex < topicCount())
        {
            int index = topicIndex + 1;
            if (topics[index].requiresQuestCompletion && Quest.complete)
            {
                return true;
            }

            if (!topics[index].requiresQuestCompletion)
            {
                return true;
            }
        }
        return false;
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
