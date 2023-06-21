using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool LoadThirdScene;

    // Start is called before the first frame update
    void Start()
    {
        LoadThirdScene = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadThirdScene = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<DrawerMechanic>() != null)
                {
                    var selection = hit.transform;
                    var selectionItem = selection.GetComponent<DrawerMechanic>();
                    selectionItem.Speed = 0;

                }
            }
        }
    }

}
