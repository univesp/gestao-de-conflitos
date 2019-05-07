using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour {
	public GameObject cutscene3;


	public bool firstTime = true;

	private void Update() {
		if(cutscene3.activeSelf)
		{
			if(firstTime)
			{
				print("Entrou na cutscene");
				firstTime = false;
				StartCoroutine(Cutscene3());
			}
		}
	}

	private IEnumerator Cutscene3()
	{
		print("Entrou Coroutine");
		cutscene3.SetActive(true);
		yield return new WaitForSeconds(3.58f);
		print("Saiu Coroutine");
		cutscene3.SetActive(false);
	}
}
