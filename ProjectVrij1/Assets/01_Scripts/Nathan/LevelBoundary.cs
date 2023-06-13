using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public bool OnTheDrawer;
    // Start is called before the first frame update
    void Start()
    {
        OnTheDrawer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTheDrawer = true;
    }
}
