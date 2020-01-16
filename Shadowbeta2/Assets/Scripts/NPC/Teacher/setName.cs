using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class setName : MonoBehaviour
{
    public Conversation conversation;
    public TextMeshPro tmp;

    private void Start()
    {
        tmp.text = conversation.Talker;
    }
}
