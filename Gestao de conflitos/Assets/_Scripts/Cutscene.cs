using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {
	public DialogueTrigger proxFala;
	public Collider2D PCCollider;
	public NPC PC;

    private bool canClick;
    private bool isPosCutscene;

	private void OnEnable() {
		PCCollider.enabled = false;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			PC.SetNGo(proxFala);
			gameObject.SetActive(false);
		}

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isPosCutscene)
            {
                if (!canClick)
                {
                    canClick = true;
                }
                else
                {
                    canClick = false;
                    PC.SetNGo(proxFala);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                PC.SetNGo(proxFala);
                gameObject.SetActive(false);
            }
        }
	}

    public void SetPosCutscene()
    {
        isPosCutscene = true;
    }
}
