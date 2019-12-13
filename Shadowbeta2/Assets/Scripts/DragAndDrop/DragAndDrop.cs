using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject defaultLocation;
    public string GuessText;
    public int sortingLayer;
    public GameObject AnswerObject;

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
        if (answerLocationTransform != null)
        {
            hackBoxTransform.position = answerLocationTransform.position;
        }
        else
        {
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
