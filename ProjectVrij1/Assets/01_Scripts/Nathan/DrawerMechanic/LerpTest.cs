// A longer example of Vector3.Lerp usage.
// Drop this script under an object in your scene, and specify 2 other objects in the "startMarker"/"endMarker" variables in the script inspector window.
// At play time, the script will move the object along a path between the position of those two markers.

using UnityEngine;
using System.Collections;

public class LerpTest : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    float fractionOfJourney;

    public bool GoForward;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        // calculate the journey lenght backwards.
        journeyLength = Vector3.Distance(endMarker.position, startMarker.position);

    }

    // Move to the target end position.
    void Update()
    {
        //// Distance moved equals elapsed time times speed..
        //float distCovered = (Time.time - startTime) * speed;

        //// Fraction of journey completed equals current distance divided by total distance.
        //float fractionOfJourney = distCovered / journeyLength;

        //Debug.Log(fractionOfJourney);
        //// Set our position as a fraction of the distance between the markers.
        //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

        //goForward();
        //goBackWard();
        switchingDirections();
    }


    private void switchingDirections()
    {
        if(GoForward == true)
        {
            goForward();
        }

        else if(GoForward == false)
        {
            goBackWard();
        }
    }

    private void goForward()
    {
        
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

        if(transform.position == endMarker.position)
        {
            Debug.Log("A");
            GoForward = false;
        }

    }

    private void goBackWard()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        //transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fractionOfJourney);
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);


        if (transform.position == startMarker.position)
        {
            Debug.Log("B");
            GoForward = true;

        }
    }
}