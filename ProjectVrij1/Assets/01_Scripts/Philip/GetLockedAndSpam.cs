using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLockedAndSpam : MonoBehaviour
{
	private bool isSpammable = false;
	private int spamAmount;
	[SerializeField] private float spamTotal;
	[SerializeField] private Animator animController;

	private void Update()
	{
		if (isSpammable)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				spamAmount++;
			}
		}	

		if (spamAmount >= spamTotal)
		{
			Debug.Log("succeed");
		}
	}

	public void EventDemon()
	{
		animController.SetBool("Demon", true);
		isSpammable = true;
	}
}
