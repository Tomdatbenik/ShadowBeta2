﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Conversation : ScriptableObject
{
    public int topicIndex = 0;
    public List<Topic> topics;

    public string Talker;

    public void NextTopic()
    {
        if (canGoToNextTopic())
            topicIndex++;
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
        if (topicIndex < topicCount() - 1)
            return true;
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