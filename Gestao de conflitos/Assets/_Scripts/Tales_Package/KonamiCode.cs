using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KonamiCode : MonoBehaviour {

	KeyCode[] konamicode;
	public int currentKeyIndex = 0;

	public UnityEvent myEvent;

	void Start () {

		konamicode = new KeyCode[]{KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow,
		KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A};
	}

	void Update() {
		// Check if any key is pressed
		if (Input.anyKeyDown) {
			// Check if the next key in the code is pressed
			if (Input.GetKeyDown(konamicode[currentKeyIndex])) {
				// Add 1 to index to check the next key in the code
				currentKeyIndex++;
			}
			// Wrong key entered, we reset code typing
			else {
				currentKeyIndex = 0;    
			}
		}
		
		// If index reaches the length of the cheatCode string, 
		// the entire code was correctly entered
		if (currentKeyIndex == konamicode.Length) {
			// Cheat code successfully inputted!
			// Unlock crazy cheat code stuff
			myEvent.Invoke();
			currentKeyIndex = 0; 
		}
	}


	void OnInput(KeyCode KeyCodeValue)
	{
		if (KeyCodeValue == konamicode[currentKeyIndex]) {
			currentKeyIndex++;
			if (currentKeyIndex >= konamicode.Length)
				myEvent.Invoke();
		}
		else {
			currentKeyIndex = 0;
		}
		
	}
}
