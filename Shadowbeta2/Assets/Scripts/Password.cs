using System;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Password : MonoBehaviour
{
    public int index;
    public TextMeshProUGUI errorText;
    public TMP_InputField tmpInputField;
    public string errorMessage;
    public string[] regex;

    void Start()
    {
        tmpInputField.onValueChanged.AddListener(delegate { CharacterCheck(); });
        errorText.text = errorMessage;
    }

    public void CharacterCheck()
    {
        if (tmpInputField.text.Length > 0)
        {
            Debug.Log(GetLastChar().ToString());
            if (!Regex.IsMatch(GetLastChar().ToString(), regex[index]))
            {
                tmpInputField.text = RemoveChar();
            }
        }
    }

    private char GetLastChar()
    {
        char[] enteredCharArray = tmpInputField.text.ToCharArray();
        return enteredCharArray.Last();
    }

    private string RemoveChar()
    {
        return tmpInputField.text.Remove(tmpInputField.text.Length - 1);
    }
}
