using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGabriel : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
	}


	public void _AtivaBool(string nome){
		animator.SetBool(nome, true);
	}

	public void _DesativaBool(string nome){
		animator.SetBool(nome, false);
	}
}
