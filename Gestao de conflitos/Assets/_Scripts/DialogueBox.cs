using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueBox : MonoBehaviour {

	bool falando = false;

	public Text caixaDialogo; // Caixa onde aparece o texto de dialogo. Obs: substituir por Text mesh pro

	public Image charPortrait1; // Caixa de retrato do personagem 1 falando, normalmente o cachorro;
	public Image charPortrait2; // Caixa de retrato do personagem 2 falando

	public GameObject balao1;
	public GameObject balao2; 

	public Text charName1;
	public Text charName2;

	public GameObject gobjDialogo; // Pai d etodos os elementos da caixa de dialogo. Fica desligado quando não em uso.

	public bool primeiroDialogo = true;


	[Header("Retratos")]
	public Sprite[] portraits;

	[Header("Botões")]
	public int numButtons =0;

	public Button[] buttons;

	public Button button1;
	public Button button2;
	public Button button3;

	public GameObject filtro;

	[Header("Test Area")]

	//Test Area
	public DialogueTrigger falatest;

	public int numFala = 0;

	int numFalaLinha=0;
	int maxFalas;

	public Sprite test;

    public int dialogue;

    public ScrollbarController[] scrollbar;
    public Collider2D playerCollider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Invoke("ScrollBarHover", 0.05f);

        if (Input.GetButtonDown("Jump") && !primeiroDialogo && !ScrollBarHover()|| Input.GetKeyDown(KeyCode.Mouse0) && !primeiroDialogo && !ScrollBarHover()){
            dialogue++;
            print("Entrou 1");
            if (dialogue > 1)
            {
                maxFalas = falatest.dialogues.Length;
                if (falando)
                {
                    if (numFala < maxFalas)
                    {
                        if (numFalaLinha < falatest.dialogues[numFala].fala.Length)
                        {
                            TriggerFala(falatest, numFala, numFalaLinha);
                            numFalaLinha++;
                            if (numFalaLinha == falatest.dialogues[numFala].fala.Length)
                            {
                                numFalaLinha = 0;
                                numFala++;
                            }
                        }
                    }
                    else
                    {
                        if (falatest.opcoes.Length == 0)
                        {
                            TerminaDialogo();
                        }
                        else
                        {
                            numButtons = falatest.opcoes.Length;
                            EnableButtons();
                        }
                    }
                }
            }
		}
	}

    private bool ScrollBarHover()
    {
        if (scrollbar[0].isActiveAndEnabled)
        {
            for (int i = 0; scrollbar[i].isActiveAndEnabled && i < scrollbar.Length; i++)
            {
                if (scrollbar[i].isHovering)
                {
                    return true;
                }
            }
        }
        return false;
    }

	[ContextMenu("test")]
	public void Test(){
		string tt = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
		//RecebeDialogo(tt,true, "cachorro_pensa");
		//RecebeDialogo(falatest.dialogues[0].fala[0],falatest.dialogues[0].cachorroFala, falatest.dialogues[0].expressao  );
		//TriggerFala(falatest, 1);
	}

	[ContextMenu("test2")]
	public void Tes2t(){

	}

	[ContextMenu("Enable Buttons")]
	public void EnableButtons(){
		filtro.SetActive(true);
		button1.gameObject.SetActive(false);
		button2.gameObject.SetActive(false);
		button3.gameObject.SetActive(false);

		if(numButtons >= 1){
			button1.gameObject.SetActive(true);
			button1.GetComponentInChildren<Text>().text = falatest.opcoesTexto[0];
		}
		if(numButtons >= 2){
			button2.gameObject.SetActive(true);
			button2.GetComponentInChildren<Text>().text = falatest.opcoesTexto[1];
		}
		if(numButtons >= 3){
			button3.gameObject.SetActive(true);
			button3.GetComponentInChildren<Text>().text = falatest.opcoesTexto[2];
		}

	}


	void SetButtons(){

	}

	void TriggerFala(DialogueTrigger trigger, int num, int numLinha){
		RecebeDialogo(trigger.dialogues[num].fala[numLinha], trigger.dialogues[num].cachorroFala, trigger.dialogues[num].nomePersonagem, trigger.dialogues[num].expressao);
	}

	void RecebeDialogo(string dialogo,bool falaCachorro, string name,  string portrait){
		caixaDialogo.text = dialogo; // atualiza o texto na caixa de dialogo

		if(falaCachorro){
			Color c = charPortrait1.color;
			c.a = 0.5f;
			charPortrait2.color = Color.grey;
			charPortrait1.color = Color.white;

			charPortrait1.sprite = GetPortrait(portrait);
			charPortrait1.SetNativeSize();

			balao1.SetActive(true);
			balao2.SetActive(false);

			charName1.text = name;

			//Toca som do diálogo do cachorro
			if(primeiroDialogo)
			{
				AudioManager.instance.PlayDialogoCachorroSFX();
				primeiroDialogo = false;
			}
		}else{

			Color c = charPortrait1.color;
			c.a = 0.5f;
			charPortrait1.color = Color.grey;
			charPortrait2.color = Color.white;

			charPortrait2.sprite = GetPortrait(portrait);
			charPortrait2.SetNativeSize();

			balao2.SetActive(true);
			balao1.SetActive(false);

			charName2.text = name;

			//Toca som do diálogo genérico
			if(primeiroDialogo)
			{
				AudioManager.instance.PlayDialogoGenericoSFX();
				primeiroDialogo = false;
			}
		}
		
	}


	Sprite GetPortrait(string name){
		foreach(Sprite sp in portraits){
			if(sp.name == name)
				return sp;
		}
		return null;
	}

	public void TesteDialogo(DialogueTrigger dTrigger){
		falatest = dTrigger;
		IniciaDialogo();
	}


	public void IniciaDialogo(){
		if(!falando){ //Corrigir bug
			falando = true;
			numFala = 1;
		}else
			numFala = 0;

		
		gobjDialogo.SetActive(true);
        playerCollider.enabled = false;
		DisableButtuns();
		
		numFalaLinha = 0;
		TriggerFala(falatest, 0,0);
		//numFala = 1;
		//numFalaLinha = 1;
		Time.timeScale = 0;
	}

	public void TerminaDialogo(){
		primeiroDialogo = true;
        dialogue = 0;
		falando = false;
		falatest.posConversa.Invoke();

		gobjDialogo.SetActive(false);
        playerCollider.enabled = true;
		numFala = 0;
		Time.timeScale = 1;
		
	}

	void DisableButtuns(){
		filtro.SetActive(false);
		foreach(Button b in buttons){
			b.gameObject.SetActive(false);
		}
		button1.gameObject.SetActive(false);
		button2.gameObject.SetActive(false);
		button3.gameObject.SetActive(false);
	}

	public void Opcao1(){
		if(falatest.opcoes.Length >=1)
			falatest.opcoes[0].Invoke();
	}

	public void Opcao2(){
		if(falatest.opcoes.Length >=2)
			falatest.opcoes[1].Invoke();
	}

	public void Opcao3(){
		if(falatest.opcoes.Length >=3)
			falatest.opcoes[2].Invoke();
	}
}
