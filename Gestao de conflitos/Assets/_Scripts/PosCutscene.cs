using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCutscene : MonoBehaviour {
	public Collider2D PCCol;
    private bool canClick;

	private void OnEnable() {
		PCCol.enabled = false;
	}

	private void OnDisable()
	{
		PCCol.enabled = true;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			gameObject.SetActive(false);
		}

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!canClick)
            {
                canClick = true;
            }
            else
            {
                Debug.Log("Desativou cutscene");
                gameObject.SetActive(false);
                canClick = false;
            }
        }

    }
}
