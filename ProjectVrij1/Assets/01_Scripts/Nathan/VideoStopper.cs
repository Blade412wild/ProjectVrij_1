using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoStopper : MonoBehaviour
{
    public VideoPlayer clip1;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
            clip1.Stop();
            canvas.SetActive(false);
        }

    }
}
