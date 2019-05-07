using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NPC : MonoBehaviour {

	public DialogueTrigger myFala;

	//public GameObject icon2;

	public SpriteRenderer icon;

	public Sprite on;
	public Sprite off;

	public UnityEvent interaction;

	public Animator elevadorCima;
	public SpriteRenderer portaEsquerdaCima;
	public SpriteRenderer portaDireitaCima;
	public SpriteMask spMaskCima;
	public Animator elevadorBaixo;
	public SpriteRenderer portaEsquerdaBaixo;
	public SpriteRenderer portaDireitaBaixo;
	public SpriteMask spMaskBaixo;
	private Player player;
	private bool ridingElevator;


	public Sprite conversaNormalOn;
	public Sprite conversaNormalOff;
	public Sprite importanteOn;
	public Sprite importanteOff;

	public bool isCutscene;
	public GameObject cutscene2;
	public GameObject portrait;
	public bool posCutscene;
	public GameObject posCutscene2;

	bool playerOn =false;  // Caso o player estaja na area de interaçãos

	// Use this for initialization
	void Start () {
		//icon = GetComponentInChildren<SpriteRenderer>();
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerOn && Input.GetButtonDown("Jump"))
		{
            Action();
		}
	}

    public void Action()
    {
        if (isCutscene)
        {
            cutscene2.SetActive(true);
            portrait.SetActive(false);
            isCutscene = false;
            posCutscene = true;
        }
        else if (posCutscene)
        {
            posCutscene2.SetActive(true);
        }
        else
        {
            Interaction();
        }
    }

	void Interaction(){
		interaction.Invoke();
		playerOn = false;
		icon.sprite = off;
	}

	void PlayerEnter(){
		//icon.gameObject.SetActive(true);
		icon.sprite = on;
        
	}

	void PlayerExit(){
		icon.sprite = off;
        player.SetNPC(null);
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.tag == "Player"){

            PlayerEnter();
            playerOn = true;
		}
		if(this.name == "elevador_entrada")
		{
			AudioManager.instance.PlayElevadorOverSFX();
		}
			
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.tag == "Player"){
            player.SetNPC(this);
            //if(/* Input.GetButtonDown("Jump")*/ Input.GetKeyDown(KeyCode.Space))
            //interaction.Invoke();
        }
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player"){
			PlayerExit();
			playerOn = false;
		}
	}

    // Funcoes de interacao

    public void CallElevadorDesce(){
		if(!ridingElevator)
			StartCoroutine(ElevadorDesce());
	}

	public void CallElevadorSobe(){
		if(!ridingElevator)
			StartCoroutine(ElevadorSobe());
	}

	public void SetConversaNormalSprite(SpriteRenderer targetSpriteRenderer)
	{
		icon.sprite = conversaNormalOff;
		on = conversaNormalOn;
		off = conversaNormalOff;
	}

	public void SetConversaImportanteSprite(SpriteRenderer targetSpriteRenderer)
	{
		icon.sprite = importanteOff;
		on = importanteOn;
		off = importanteOff;
	}


	public void MinhaFala(){
		FindObjectOfType<DialogueBox>().TesteDialogo(myFala);
	}

	public void SetFala(DialogueTrigger dTrigger){
		myFala = dTrigger;
	}

	public void SetNGo(DialogueTrigger dTrigger){
		AudioManager.instance.PlayDialogoRespondeSFX();
		myFala = dTrigger;
		MinhaFala();
	}

	public void SetNGo2(DialogueTrigger dTrigger){
		StartCoroutine(gogo(dTrigger));

	}

	IEnumerator gogo(DialogueTrigger dTrigger){
		yield return new WaitForSeconds(0.5f);
		myFala = dTrigger;
		MinhaFala();
	}

	public void PosicaoCoruja(){
		transform.position = new Vector3(-3.9f,2.4f,0);
	}

	IEnumerator ElevadorSobe()
	{
		ridingElevator = true;
		player.enabled = false;
		portaDireitaBaixo.enabled = true;
		portaEsquerdaBaixo.enabled = true;
		spMaskBaixo.enabled = true;
		//Animação do elevador de baixo fechando
		elevadorBaixo.Play("Fecha");
		//Som da porta
		AudioManager.instance.PlayElevadorPortaSFX();
		yield return new WaitForSeconds(1.0f);
		//Toca som do elevador andando
		//Animação do elevador de cima abrindo
		GlobalVars.mainPlayer.position += Vector3.up * 3.48f;
		//Toca som do elevador chegando
		AudioManager.instance.PlayElevadorPortaSFX();
		elevadorCima.Play("Abre");
		yield return new WaitForSeconds(1.0f);
		portaDireitaCima.enabled = false;
		portaEsquerdaCima.enabled = false;
		spMaskCima.enabled = false;
		player.enabled = true;
		ridingElevator = false;
	}

	IEnumerator ElevadorDesce()
	{
		ridingElevator = true;
		player.enabled = false;
		portaDireitaCima.enabled = true;
		portaEsquerdaCima.enabled = true;
		spMaskCima.enabled = true;
		elevadorCima.speed = 1;
		elevadorCima.Play("Fecha");
		AudioManager.instance.PlayElevadorPortaSFX();
		yield return new WaitForSeconds(0.6f);
		GlobalVars.mainPlayer.position += Vector3.down * 3.48f;
		AudioManager.instance.PlayElevadorPortaSFX();
		elevadorBaixo.Play("Abre");
		yield return new WaitForSeconds(0.6f);
		portaDireitaBaixo.enabled = false;
		portaEsquerdaBaixo.enabled = false;
		spMaskBaixo.enabled = false;
		player.enabled = true;
		ridingElevator = false;
	}

	public void SetCutscene()
	{
		isCutscene = true;
	}

    public void SetPosCutscene()
    {
        posCutscene = true;
    }
}