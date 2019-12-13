using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject defaultLocation;
    public string GuessText;
    public int sortingLayer;
    public GameObject AnswerObject;
    public GameObject DefaultParent;

    private bool dragging;
    private float distance;
    private Transform defaultLocationTransform;
    private Transform hackBoxTransform;
    private int defaultSortingOrder;
    private SpriteRenderer hackBoxSpriteRenderer;
    private TextMeshPro hackBoxText;
    private Transform answerLocationTransform;

    // Start is called before the first frame update
    void Start()
    {
        defaultLocationTransform = defaultLocation.GetComponent<Transform>();
        hackBoxTransform = GetComponent<Transform>();

        hackBoxSpriteRenderer = GetComponent<SpriteRenderer>();
        defaultSortingOrder = hackBoxSpriteRenderer.sortingOrder;

        //Gets first child element of the object this script is on and of that child object gets the TextMeshPro
        hackBoxText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        hackBoxText.text = GuessText;

        hackBoxTransform.position = defaultLocationTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }

        if (hackBoxTransform.parent == null)
        {
            hackBoxTransform.parent = defaultLocationTransform;
            hackBoxTransform.position = defaultLocationTransform.position;
        }
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        hackBoxSpriteRenderer.sortingOrder = sortingLayer;
        hackBoxText.sortingOrder = sortingLayer + 1;
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
        hackBoxSpriteRenderer.sortingOrder = defaultSortingOrder;
        hackBoxText.sortingOrder = defaultSortingOrder + 1;
        //If answerlocation doesn't have a child element, set current hackbox as childelement
        if (answerLocationTransform != null && answerLocationTransform.childCount == 0)
        {
            hackBoxTransform.parent = answerLocationTransform;
            hackBoxTransform.position = answerLocationTransform.position;
        }
        //Else if answerlocation has child element, set this hackbox as child
        else if (answerLocationTransform != null && answerLocationTransform.childCount > 0)
        {
            answerLocationTransform.DetachChildren();
            hackBoxTransform.parent = answerLocationTransform;
            hackBoxTransform.position = answerLocationTransform.position;
        }
        //Else if answerLocationTransform is null set hackbox back to default location
        else if (answerLocationTransform == null)
        {
            hackBoxTransform.parent = DefaultParent.transform;
            hackBoxTransform.position = defaultLocationTransform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("HackAnswer"))
        {
            answerLocationTransform = other.transform;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (answerLocationTransform == null && other.name.Contains("HackAnswer"))
        {
            answerLocationTransform = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name.Contains("HackAnswer"))
        {
            answerLocationTransform = null;
        }
    }
}
