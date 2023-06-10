using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
	[SerializeField] private Animator anim;
	[SerializeField] private GameObject demon;
	[SerializeField] private Demon demonScript;
	public bool DayOrNight;

	private void Awake()
	{
		DayOrNight = true;
		demonScript.enabled = false;
		demon.SetActive(false);
	}

	private void Update()
	{
		//day
		if (DayOrNight)
		{
			anim.SetInteger("DNC", 1);
			demonScript.enabled = false;
			demon.SetActive(false);
		}
		//night
		if (!DayOrNight)
		{
			anim.SetInteger("DNC", 0);
			StartCoroutine(ShowDemon());
		}
	}

	IEnumerator ShowDemon()
	{
		yield return new WaitForSeconds(2);
		demonScript.enabled = true;
		demon.SetActive(true);
	}


}
