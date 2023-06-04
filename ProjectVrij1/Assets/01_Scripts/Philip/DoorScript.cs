using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;

public class DoorScript : MonoBehaviour
{
	[SerializeField] private GameObject playerObj;
	[SerializeField] private GetLockedAndSpam lockAndSpam;
	private CinemachineVirtualCamera cinemachineVirtualCamera;
	private ThirdPersonController thirdPersonController;
	private bool isColliding;

	private void Awake()
	{

		cinemachineVirtualCamera = playerObj.GetComponent<CinemachineVirtualCamera>();
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
			lockAndSpam.EventDemon();
		}
	}
}