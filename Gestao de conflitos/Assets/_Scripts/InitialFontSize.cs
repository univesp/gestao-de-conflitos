using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialFontSize : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetInt("fontSize" ,30);
	}
}
