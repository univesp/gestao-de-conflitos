using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GAF.Core
{
	public class TesteGAFAnim : MonoBehaviour {



		public GAFMovieClip totoro;

		// Use this for initialization
		void Start () {
			totoro = GetComponentInChildren<GAFMovieClip>();
            SetIdle();
		}
		
		// Update is called once per frame
		void Update () {

			if(Time.timeScale != 0){ // Previne de animações mudarem enquanto o jog estiver pausado / em fala

                //if (Input.GetAxisRaw("Horizontal") == 0)
                if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
					totoro.setSequence("idle_right", true);


				//if(Input.GetAxisRaw("Horizontal")==-1){
                if(Input.GetKey(KeyCode.LeftArrow))
                { 
					transform.localScale = new Vector3 (-1,1,1);
					totoro.setSequence("walk_right", true);
					//totoro.play();
				}


            //if(Input.GetAxisRaw("Horizontal")==1){
            if(Input.GetKeyDown(KeyCode.RightArrow)){
					transform.localScale = Vector3.one;
					totoro.setSequence("walk_right", true);
					//totoro.play();
				}


				/*
				if(Input.GetKeyDown(KeyCode.RightArrow)){
					totoro.setSequence("walk_right", true);
					totoro.play();
				}else if(Input.GetKeyDown(KeyCode.LeftArrow)){
					totoro.setSequence("walk_left", true);
					totoro.play();
				 }/* else if(Input.GetKeyDown(KeyCode.DownArrow)){
					totoro.setSequence("idle_right", true);
					totoro.play();
				}*/

			}
		}

        public void SetIdle()
        {
            totoro.setSequence("idle_right", true);
        }

        public void SetRight()
        {
            transform.localScale = Vector3.one;
            totoro.setSequence("walk_right", true);
        }

        public void SetLeft()
        {
            transform.localScale = new Vector3(-1, 1, 1);
            totoro.setSequence("walk_right", true);
        }
	}
}
