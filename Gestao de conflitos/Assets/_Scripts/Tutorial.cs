using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
	public GameObject sobreOJogo;
	public GameObject comoJogar;
	public SceneLoader sceneLoader;
	private int tutorialIndex = 0;

	public void NextScreen()
	{
		tutorialIndex++;
		if(tutorialIndex == 1)
		{
			sobreOJogo.SetActive(false);
			comoJogar.SetActive(true);
		}
		else
		{
			sceneLoader.MyLoadScene(1);
		}
	}
}
