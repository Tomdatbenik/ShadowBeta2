using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject defaultLocation;
    public string GuessText;

    private bool dragging = false;
    private float distance;
    private Transform defaultLocationTransform;
    private Transform HackBoxTransform;
    private TextMeshPro test;

    // Start is called before the first frame update
    void Start()
    {
        defaultLocationTransform = defaultLocation.GetComponent<Transform>();
        HackBoxTransform = GetComponent<Transform>();
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = GuessText;
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
        //TODO check if hackbox is in a emtpy location box, otherwise snap back to location
        else if(!dragging)
        {
            HackBoxTransform.position = defaultLocationTransform.position;
        }
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    
}
