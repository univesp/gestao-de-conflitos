using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GAF.Core;

public class Player : MonoBehaviour {

	float speed = 2.2f;

	bool andarEsq =true;
	bool andarDir = true;

    Vector3 targetPoint;
    public bool playerIsMoving = false;
    public TesteGAFAnim animation;

    private NPC npc;

	// Use this for initialization
	public void Start () {
		GlobalVars.mainPlayer = transform;
	}
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKey(KeyCode.LeftArrow) && andarEsq) || (Input.GetKey(KeyCode.RightArrow) && andarDir))
        {
            transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            playerIsMoving = false;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerIsMoving = true;
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(targetPoint.x < transform.position.x)
            {
                animation.SetLeft();
            }
            if(targetPoint.x > transform.position.x)
            {
                animation.SetRight();
            }
        }

        if(playerIsMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPoint.x, transform.position.y, transform.position.z), speed * Time.deltaTime);            
        }

        if (playerIsMoving && targetPoint.x - transform.position.x <= 0.02f && targetPoint.x - transform.position.x >= -0.02f)
        {
            playerIsMoving = false;
            animation.SetIdle();
        }

    }

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Parede"){
            playerIsMoving = false;
            animation.SetIdle();
			if(other.transform.position.x < transform.position.x){ // parede esta a esquerda
				andarEsq = false;
			}else{
				andarDir = false;
			}
		}
    }

	private void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Parede"){
			//if(other.transform.position.x < transform.position.x){ // parede esta a esquerda
				andarEsq = true;
			//}else{
				andarDir = true;
			//}
		}
	}

    public void SetNPC(NPC newNPC)
    {
        npc = newNPC;
    }

    private void OnMouseDown()
    {
        if(npc != null)
        {
            npc.Action();
        }
    }

    public void ElevadorDesce(){
		transform.position += Vector3.down * 3.48f;
	}
}
