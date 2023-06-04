using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;

public class DoorScript : MonoBehaviour
{
	[SerializeField] private GameObject playerObj;
	[SerializeField] private GameObject cameraPlacementPlayer;
	[SerializeField] private GetLockedAndSpam lockAndSpam;
	[SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
	private ThirdPersonController thirdPersonController;
	private bool isColliding;

	private void Awake()
	{
		thirdPersonController = playerObj.GetComponent<ThirdPersonController>();
		thirdPersonController.enabled = true;
		isColliding = false;
	}

	private void Update()
	{
		InputTrigger();
	}

	private void OnTriggerEnter(Collider other)
	{
		isColliding = true;
	}

	void InputTrigger()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isColliding)
		{
			thirdPersonController.enabled = false;
			cinemachineVirtualCamera.Follow = null;
			lockAndSpam.EventDemon();
		}
	}

	public void EnableEverythingAgain()
	{
		CinemachineBasicMultiChannelPerlin noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		noise.m_FrequencyGain = 0.5f;

		thirdPersonController.enabled = true;
		cinemachineVirtualCamera.Follow = cameraPlacementPlayer.transform;
		isColliding = false;
	}
}