using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMarker : MonoBehaviour
{
    public bool DidWin;
    // Start is called before the first frame update
    void Start()
    {
        DidWin = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ElectricityTest>())
        {
            DidWin = true;
        }
    }
}
