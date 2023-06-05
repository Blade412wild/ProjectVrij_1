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
            var selectionItem = selection.GetComponent<Item>();
            if(selectionItem != null)
            {
                selectionItem.RayIntersection = true;
            }
        }
    }
}
