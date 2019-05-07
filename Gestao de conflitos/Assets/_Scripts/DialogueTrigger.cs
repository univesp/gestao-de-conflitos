using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour {
	
	public TextAsset json;

	public Fala[] dialogues;
	public UnityEvent posConversa;

	public string[] opcoesTexto;

	public UnityEvent[] opcoes;

	void Start(){
		if(json != null)
			LoadJson();
	}

	public void TriggerDialogue(){

		//FindObjectOfType<MngDialogue>().StartDialogue(dialogue);
		FindObjectOfType<MngDialogue>().StartDialogues(dialogues);

	}

	public void TriggerDialogueEvent(){

		//FindObjectOfType<MngDialogue>().StartDialogue(dialogue);
		FindObjectOfType<MngDialogue>().StartDialogues(dialogues, posConversa);

	}

	public void TriggerDialogueEventPriority(){

		//FindObjectOfType<MngDialogue>().StartDialogue(dialogue);
		FindObjectOfType<MngDialogue>().StartDialoguesPriority(dialogues, posConversa);

	}

	[ContextMenu("Load Json")]
	void LoadJson(){

		dialogues = JsonHelper.getJsonArray<Fala>(json.text);
		transform.name = json.name;
	}

}
