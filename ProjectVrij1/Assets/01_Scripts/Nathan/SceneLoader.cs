using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
