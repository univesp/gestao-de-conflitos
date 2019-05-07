using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void MyLoadScene(int numLoadScene){
		Time.timeScale = 1;
		SceneManager.LoadScene(numLoadScene);
	}

	public void MyLoadScene(string nameLoadScene){
		Time.timeScale = 1;
		SceneManager.LoadScene(nameLoadScene);
	}

	public void ReloadScene(){
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

}
