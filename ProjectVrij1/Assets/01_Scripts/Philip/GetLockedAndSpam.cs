using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetLockedAndSpam : MonoBehaviour
{
	private bool isSpammable = false;
	private int spamAmount;
	[SerializeField] private float spamTotal;
	[SerializeField] private GameObject DemonObj;
	[SerializeField] private GameObject cameraRoot;
	[SerializeField] private Animator animController;
	[SerializeField] private Animator animControllerDemon;
	[SerializeField] private Animator animControllerModel;
	[SerializeField] private string stringScne;
	[SerializeField] DoorScript doorScript;
	[SerializeField] private Animator volumeanim;

	private void Awake()
	{
		animController.enabled = false;
		DemonObj.SetActive(false);
	}

	private void Update()
	{
		if (isSpammable)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				spamAmount++;
			}

			DemonObj.SetActive(true);
			volumeanim.SetBool("Demon", true);
			animControllerModel.SetInteger("Demon", 1);
			animControllerDemon.SetBool("Demon", true);

		}	

		if (spamAmount >= spamTotal)
		{
			doorScript.EnableEverythingAgain();
			animController.SetBool("Demon", false);
			DemonObj.SetActive(false);
			volumeanim.SetBool("Demon", false);


			animController.enabled = false;
			isSpammable = false;


			Vector3 currentPosition = cameraRoot.transform.position;
			Vector3 newPosition = new Vector3(currentPosition.x, 2.5f, currentPosition.z);
			cameraRoot.transform.position = newPosition;
		}

		AnimatorStateInfo stateInfo = animController.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.IsName("turnaround") && stateInfo.normalizedTime >= 1.0f)
		{
			SceneManager.LoadScene(stringScne);
		}
	}

	public void EventDemon()
	{
		animController.enabled = true;
		isSpammable = true;
		animController.SetBool("Demon", true);
		animControllerDemon.SetBool("Demon", true);
	}
}
