using UnityEngine;
using UnityEngine.UI;

public class MyFontSize : MonoBehaviour {

	Text setFont;

	// Use this for initialization
	void Start () {

		if(GetComponent<Text>() != null){
			setFont = GetComponent<Text>();
			ApplyChange();
			if(setFont.fontSize < 30)
				setFont.fontSize = 30;
		}
	}

	public void ChangePref(float size){
		PlayerPrefs.SetInt("fontSize" ,(int)size);
		ApplyChange();
	}

	public void ApplyChange(){
		if(setFont != null)
			setFont.fontSize = PlayerPrefs.GetInt("fontSize");
	}
}
