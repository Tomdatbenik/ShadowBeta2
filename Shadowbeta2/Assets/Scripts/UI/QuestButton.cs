using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    public Image button;
    public Sprite OpenSprite;
    public Sprite ClosedSprite;
    public QuestList QuestList;

    public GameObject questBox;
    public bool opened;

    public void Start()
    {
        opened = QuestList.open;

        if (opened)
        {
            questBox.SetActive(true);
            button.sprite = OpenSprite;
        }
        else
        {
            questBox.SetActive(false);
            button.sprite = ClosedSprite;
        }
    }

    public void Open()
    {
        questBox.SetActive(true);
        button.sprite = OpenSprite;
    }

    public void click()
    {
        opened = !opened;
        QuestList.open = opened;

        if (opened)
        {
            questBox.SetActive(true);
            button.sprite = OpenSprite;
        }
        else
        {
            questBox.SetActive(false);
            button.sprite = ClosedSprite;
        }
    }
}
