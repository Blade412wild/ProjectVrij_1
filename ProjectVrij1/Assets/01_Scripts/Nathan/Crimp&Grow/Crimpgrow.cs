using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crimpgrow : MonoBehaviour
{
    public GameObject EndMarker;
    public GameObject StartMarker;
    public GameObject Player;

    private Vector3 TargetPos;
    private float journeyLenght;
    private float distCovered;
    private float ScaleLength = 0.4f;
    private float ScaleMultiplier;
    private float scaleRelativeToDistanceCorvered;
    


    // Start is called before the first frame update
    void Start()
    {
        journeyLenght = Vector3.Distance(StartMarker.transform.position, EndMarker.transform.position);
        ScaleMultiplier = journeyLenght / ScaleLength;
    }

    // Update is called once per frame
    void Update()
    {
        distCovered = Vector3.Distance(Player.transform.position, EndMarker.transform.position);
        float _fractionOfJourney = distCovered / journeyLenght;
        float _scaleChanger = _fractionOfJourney / ScaleLength;
        scaleRelativeToDistanceCorvered = _fractionOfJourney * ScaleMultiplier;
        Debug.Log(scaleRelativeToDistanceCorvered);

        //Debug.Log(_fractionOfJourney);
        //Debug.Log(_scaleChanger);

    }
}
