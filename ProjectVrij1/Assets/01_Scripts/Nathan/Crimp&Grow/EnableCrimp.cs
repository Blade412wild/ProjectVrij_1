using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCrimp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CrimpGrow2 _crimpGrow2 = other.GetComponent<CrimpGrow2>();
        if(_crimpGrow2 != null)
        {
            _crimpGrow2.enabled = true;
        }

    }

}
