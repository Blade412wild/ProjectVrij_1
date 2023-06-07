using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRemover : MonoBehaviour
{
    public GameObject StoryCanvas;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StoryCanvas.SetActive(false);
        }
    }
}