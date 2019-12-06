using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Animator animator;

    public Transform startMarker;

    public Transform endmarker;

    public float speed = 1.0F;

    // Total distance between the markers.
    private float journeyLength;

     private float startTime;

    void Start()
    {
        startTime = Time.time;
        endmarker = startMarker;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal < 0)
        {
            endmarker.position = new Vector2(endmarker.position.x + (float).001, endmarker.position.y);
        }
        else if(horizontal > 0)
        {
            endmarker.position = new Vector2(endmarker.position.x - (float).001, endmarker.position.y);
        }

        journeyLength = Vector2.Distance(startMarker.position, endmarker.position);

        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        if(startMarker.position != null && endmarker != null)
        {
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector2.Lerp(startMarker.position, endmarker.position, fractionOfJourney);
        }

    }
}
