using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource src;
    [SerializeField] private List<AudioClip> clipList;

    public void PlayAudio(int index)
	{
        src.clip = clipList[index];
        src.Play();
	}
}
