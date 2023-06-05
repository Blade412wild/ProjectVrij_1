using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    private Vector3 endPosition;
    private Vector3 startPosition;
    private float desiredDuration = 3f;
    private float elapsedTime;

    [SerializeField]
    private AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(-7, 0, -5);
        Debug.Log(startPosition);
        Debug.Log(" begin : end position = " + endPosition);


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("end : end position = " + endPosition);
        elapsedTime = Time.deltaTime; ;
        float percentageComplete = elapsedTime / desiredDuration;

        //transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.SmoothStep(0, 1, percentageComplete));
        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
        //transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));

    }
}
