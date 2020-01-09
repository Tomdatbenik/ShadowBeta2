﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class PlayerSpawnLocation : ScriptableObject
{
    public Spawn spawn;

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
            spawn = null;
        }
    }
    #endif

}
