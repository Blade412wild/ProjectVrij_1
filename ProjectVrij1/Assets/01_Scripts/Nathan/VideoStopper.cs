using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoStopper : MonoBehaviour
{
    public VideoPlayer clip1;
    public GameObject canvas;
    public GameObject RedDot;

    private bool IntroHasbeenPlayed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && IntroHasbeenPlayed == false)
        {
            IntroHasbeenPlayed = true;  
            clip1.Stop();
            canvas.SetActive(false);
            RedDot.SetActive(true);
        }

    }
}
