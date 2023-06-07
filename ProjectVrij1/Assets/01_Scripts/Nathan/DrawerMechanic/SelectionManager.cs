using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionItem = selection.GetComponent<DrawerMechanic>();
            //var selectionItem = selection.
            Debug.Log("er is een hit");

            if(Input.GetKeyDown(KeyCode.G))
            {
                if (selectionItem != null)
                {
                    Debug.Log("is niet null");
                    selectionItem.Speed = 0;
                }
            }
        }
 
    }

}
