using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MngDialogue : MonoBehaviour {

	//public  mono;
	bool talking = false;
	string tempLine;

	public Queue<string> sentences;

	public int actualDialoqueNumber = 0;
	int maxDialogue;

	Text textChatBox;
	Text textBoxName;
	
	public GameObject ballonText;

	public UnityEvent methods;


	bool priority = false;


	//Animation Teste

	//public Animator testAnimator;

	public string[] actorNames ={"Gerente", "Desenvolvedor 1", "Desenvolvedor 2"};

	public Animator [] actors;
	

	int actorAtual;

	public Transform[] speechBalloons;
	// something [] -> list of actors

/* 
	[Header("Ballon Animation")]
	
	public AnimationCurve animationCurve;
	public float lerpTime = 1;
	Vector3 iniScale;*/

	//teste switch


	Fala[] myDialogues;

	public UnityEvent onBallonPop;

	// Use this for initialization
	void Start () {
		//ballonText.SetActive (false);

		sentences = new Queue<string>();
	}

	void Update(){

		if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit")/*Input.anyKeyDown*/){

			DisplayNextSentence();

		}

	}

	/*
	Notes

	Separate person talkin
	trigger animation


	
	 */

	


	public void StartDialogues(Fala[] dialogues){

		myDialogues = dialogues;

		//Debug Error
		actualDialoqueNumber = 0;
		actors[actorAtual].ResetTrigger("End");


		Debug.Log ("Start Chat");

		maxDialogue = dialogues.Length;

		
		
	//	ballonText.SetActive (true);//debug error


		//ballonText.SendMessage("ZoomIn");


		//sentences.Clear ();

		// 03/23
		// test foreach sentenceS

		StartDialogue(myDialogues[actualDialoqueNumber]);


		/* 
		foreach (Dialogue dialo in dialogues){
			/* 
			foreach (string sentence in dialo.sentences) {

				sentences.Enqueue (sentence);

			}
			StartDialogue(dialo);

		}*/



		//DisplayNextSentence ();

	}

	public void StartDialoguesPriority(Fala[] dialogues, UnityEvent endEvent){

		priority = true;

		myDialogues = dialogues;

		//Debug Error
		actualDialoqueNumber = 0;
		actors[actorAtual].ResetTrigger("End");

		Debug.Log ("Start Chat");

		maxDialogue = dialogues.Length;

		//ballonText.SetActive (true); //test error debug
		
		
		//ballonText.SendMessage("ZoomIn");

		methods = endEvent;

		StartDialogue(dialogues[actualDialoqueNumber]);		

	}

	public void StartDialogues(Fala[] dialogues, UnityEvent endEvent){

		if(!priority){

			myDialogues = dialogues;

			//Debug Error
			actualDialoqueNumber = 0;
			actors[actorAtual].ResetTrigger("End");

			Debug.Log ("Start Chat");

			maxDialogue = dialogues.Length;

			//ballonText.SetActive (true); //test error debug
			
			
			//ballonText.SendMessage("ZoomIn");

			methods = endEvent;

			StartDialogue(dialogues[actualDialoqueNumber]);
		}

	}


	public void StartDialogue(Fala dialogue){
		actorAtual = numActor(dialogue.nomePersonagem);
		//Fazer erro caso nome errado

		speechBalloons[actorAtual].gameObject.SetActive (true);
		speechBalloons[actorAtual].SendMessage("ZoomIn");
		onBallonPop.Invoke();

		//Debug.Log ("Start Chat");

		//ballonText.SetActive (true);

		sentences.Clear ();

		// 03/23
		// test foreach sentenceS
/* 
		//test switch
		switch(dialogue.name){
			case actorNames[0]:
				print("bacanudco");
				break;
			default:
				print("fica pra prxima");
				break;
				}
*/
		
		//print(numActor(dialogue.name));

		//old textBoxName.text = dialogue.name;

		//old testAnimator.SetTrigger(dialogue.expression);
		actors[actorAtual].ResetTrigger("End");

		actors[actorAtual].SetTrigger(dialogue.expressao);

		ballonText = speechBalloons[actorAtual].gameObject;
		textChatBox = speechBalloons[actorAtual].GetComponentInChildren<Text>();

		foreach (string sentence in dialogue.fala) {

			sentences.Enqueue (sentence);

		}

		DisplayNextSentence ();

	}




	public void DisplayNextSentence(){
		StopAllCoroutines();

		if(talking){ // Acelera Texto, preenche todo quadro
			textChatBox.text = tempLine;
			talking = false;
			
		}else{

			if (sentences.Count == 0) { // fix
				NextDialogue();//EndDialogue ();
				return;
			}

			string chatText = sentences.Dequeue ();
			tempLine = chatText;

			StartCoroutine(TypeSentence(chatText)); //old //textChatBox.text = chatText;
		}

	}

	IEnumerator TypeSentence(string textSentence){
		talking = true;

		textChatBox.text = "";
		foreach(char letter in textSentence.ToCharArray()){
			textChatBox.text += letter;
			yield return null;
		}
		talking = false;
	}

	public void NextDialogue(){
		actualDialoqueNumber ++;

		//test ballon
		if(ballonText != null)
			ballonText.SetActive (false);

		actors[actorAtual].SetTrigger("End"); // test end // testar se actor diferente

		if(actualDialoqueNumber>=maxDialogue){ // Se Acabaram todos os dialogos
			EndDialogue();
		}else{


			StartDialogue(myDialogues[actualDialoqueNumber]);

		}

	}

	void EndDialogue(){

		//test end
		//	testAnimator.SetTrigger("End");
		actors[actorAtual].SetTrigger("End");

		Debug.Log ("end chat");
		ballonText.SetActive (false); // Desliga Balao
		EndDialogueEvents();
	}

	void EndDialogueEvents(){

		priority = false;
		//objSendMsg.SendMessage(sendMessageName, true);
		//Debug Fix
		if(methods != null)
			methods.Invoke();
	}

/* 
	public void BallonZoomIn(){
		StartCoroutine(LerpIn(lerpTime));
	}

	IEnumerator LerpIn(float durTime){

		float tTime = 0;;

		while(tTime<=durTime){
			//transform.localScale = Vector3.Slerp(Vector3.zero, Vector3.one, animationCurve.Evaluate( tTime/durTime));
			//camera.orthographicSize = Mathf.Lerp(firstSize,secondSize, tTime/durTime);

			ballonText.transform.localScale = iniScale * animationCurve.Evaluate( tTime/durTime);

			tTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}*/

	public void ClearMethods(){
		methods = null;
	}


	public int numActor(string nomeActor){

		for(int i = 0; i < actorNames.Length; i++){
			if(nomeActor == actorNames[i]){
				return i;
			}
		}

		Debug.LogError("Ator não encontrado");
		return -1;

	}

}
