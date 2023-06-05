using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool RayIntersection;

    private void Start()
    {
        RayIntersection = false;
    }

    private void Update()
    {
        Debug.Log(RayIntersection);
    }


}
