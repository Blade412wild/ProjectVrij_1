using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondSceneLoader : MonoBehaviour
{
    public DoorScript doorSCript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

            if (hit.transform.GetComponent<DoorScript>() != null && doorSCript.AnimationHasBeenPlayed == true)
            {
                SceneManager.LoadScene("ChildCoupe");

            }
        }
    }
}
