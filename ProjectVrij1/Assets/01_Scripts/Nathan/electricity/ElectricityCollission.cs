using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityCollission : MonoBehaviour
{
    public bool IsCollission;
    // Start is called before the first frame update
    void Start()
    {
        IsCollission = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsCollission = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        IsCollission = false;
    }
}
