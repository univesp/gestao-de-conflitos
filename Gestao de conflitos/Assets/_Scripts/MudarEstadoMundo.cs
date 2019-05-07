using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarEstadoMundo : MonoBehaviour {

	public NPC gato;

	public NPC pinguim;

	public NPC coruja;

	public  NPC hamster;

	public NPC tartaruga;


	[Header("Dialogos")]
	public DialogueTrigger gatoDialogo;

	public DialogueTrigger pinguimDialogo;

	public DialogueTrigger corujaDialogo;

	public DialogueTrigger hamsterDialogo;

	public DialogueTrigger tartarugaDialogo;


	[ContextMenu("Mudar Mundo")]
	public void MudarMundo(){
		if(gato != null && gatoDialogo != null)
			gato.SetFala(gatoDialogo);
		if(pinguim != null && pinguimDialogo != null)
			pinguim.SetFala(pinguimDialogo);
		if(coruja != null && corujaDialogo != null)
			coruja.SetFala(corujaDialogo);
		if(hamster != null && hamsterDialogo != null)
			hamster.SetFala(hamsterDialogo);
		if(tartaruga != null && tartarugaDialogo != null)
			tartaruga.SetFala(tartarugaDialogo);
	}
}
