using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Transform defaultLocation;
    public string GuessText;
    public int sortingLayer;
    public GameObject answerObject;
    [Range(1, 2)]
    public float percentageWidth;

    private bool dragging;
    private float distance;
    private Transform hackBoxTransform;
    private int defaultSortingOrder;
    private SpriteRenderer hackBoxSpriteRenderer;
    private TextMeshPro hackBoxText;
    private Transform answerLocationTransform;

    // Start is called before the first frame update
    void Start()
    {
        hackBoxTransform = GetComponent<Transform>();

        hackBoxSpriteRenderer = GetComponent<SpriteRenderer>();
        defaultSortingOrder = hackBoxSpriteRenderer.sortingOrder;
        
        hackBoxText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        hackBoxText.text = GuessText;

        hackBoxTransform.position = defaultLocation.position;
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
            hackBoxTransform.parent = defaultLocation;
            hackBoxTransform.position = defaultLocation.position;
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

        if (answerLocationTransform != null && answerLocationTransform.childCount == 0)
        {
            SetHackBoxLocation(hackBoxTransform, answerLocationTransform, percentageWidth);
        }

        else if (answerLocationTransform != null && answerLocationTransform.childCount > 0)
        {
            answerLocationTransform.GetChild(0).GetComponent<Transform>().GetChild(0).GetComponent<TextMeshPro>().color = Color.white;
            answerLocationTransform.DetachChildren();
            SetHackBoxLocation(hackBoxTransform, answerLocationTransform, percentageWidth);
        }

        else if (answerLocationTransform == null)
        {
            SetHackBoxLocation(hackBoxTransform, defaultLocation, 1);
        }


    }

    public void SetHackBoxLocation(Transform hackbox, Transform wantedLocation, float percentage)
    {
        hackbox.parent = wantedLocation;
        hackbox.position = new Vector3(wantedLocation.position.x / percentage, wantedLocation.position.y);
        hackbox.GetChild(0).GetComponent<TextMeshPro>().color = Color.white;
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
