using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quiz : ScriptableObject
{
    public Topic introduction;
    public Topic onFail;
    public Topic onSucces;
    public List<Question> questions;
}
