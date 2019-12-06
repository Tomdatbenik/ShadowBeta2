using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Animator animator;

    public Transform startMarker;
    public Transform endMarkerLeft;
    public Transform endMarkerRight;

    public Transform endmarker;

    public float speed = 1.0F;

    private float journeyLength;

    private float startTime;

    bool transition = false;

    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal < 0)
        {
            journeyLength = Vector2.Distance(startMarker.position, endMarkerLeft.position);
            endmarker = endMarkerLeft;
        }
        else if (horizontal > 0)
        {
            journeyLength = Vector2.Distance(startMarker.position, endMarkerRight.position);
            endmarker = endMarkerRight;
        }
        else
        {
            journeyLength = Vector2.Distance(startMarker.position, startMarker.position);
            endmarker = startMarker;
        }

        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endmarker.position, fractionOfJourney);
    }
}
