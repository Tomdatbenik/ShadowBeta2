using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Topic : ScriptableObject
{
    [TextArea(3, 10)]
    public List<string> Sentences;
}
