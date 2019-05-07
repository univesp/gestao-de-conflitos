using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FalarTodos : MonoBehaviour {
	public bool falou = false;

	public bool gato, pinguim, tartaruga, hamster;

	public UnityEvent todosFalaram;

	// Update is called once per frame
	void Update () {
		
		if(!falou){
			if(gato && pinguim && tartaruga && hamster){
				todosFalaram.Invoke();
				falou = true;
			}
		}

	}

	public void gatoFalou(){
		gato=true;
	}

	public void pinguimFalou(){
		pinguim=true;
	}

	public void tartarugaFalou(){
		tartaruga=true;
	}

	public void hamsterFalou(){
		hamster=true;
	}
}
