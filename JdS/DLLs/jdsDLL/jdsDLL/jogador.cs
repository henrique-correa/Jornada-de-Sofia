using UnityEngine;
using System.Collections;


[RequireComponent(typeof(PlatformerCharacter2D))]
[RequireComponent(typeof(Platformer2DUserControl))]
[RequireComponent(typeof(manager))]

public class jogador : MonoBehaviour {

	[SerializeField]float tempo_de_corda =900.0f;
	[SerializeField]int vida = 3;
	Vector2 npos;
	GameObject texto;
	GameObject texto2;
	GameObject texto3;
	bool resetspeed = false;
	[SerializeField]int bj = 0;
	bool colidiuPASSARO = false;

	PlatformerCharacter2D charac;
	Platformer2DUserControl charac2;

	// Use this for initialization
	void Start () {
		texto = GameObject.Find("debug_1");
		texto2 = GameObject.Find("debug_2");
		texto3 = GameObject.Find("debug_3");

		charac = GetComponent<PlatformerCharacter2D>();
		charac2 = GetComponent<Platformer2DUserControl>();
	
	}
	
	// Update is called once per frame
	void Update () {
		tempo_de_corda -= 1.0f;
		//if (tempo_de_corda < 1.0f){


		if(resetspeed == true){
			charac.RESETMaxSpeed();
			resetspeed = false;
		}
		texto.guiText.text = tempo_de_corda.ToString("0.0");
		if(tempo_de_corda <= 0){
			texto.guiText.text = "gameover";

		}
		if(vida <=0){
			Destroy(gameObject);
		}
		if(colidiuPASSARO == true){
			charac2.trancadoPassaro = true;
			if(Input.GetButtonDown("Jump")){
				bj++;
			}
		}
		if(bj > 10){
			charac2.trancadoPassaro = false;
			colidiuPASSARO = false;
			bj = 0;
		}
		 

	
	}
	void OnTriggerEnter2D(Collider2D col){

		texto2.guiText.text = col.gameObject.name;
		if(col.gameObject.name == "chave_de_corda"){
			tempo_de_corda += 100.0f;
			Destroy(col.gameObject);
			Debug.Log("colidiu");
			}
		if(col.gameObject.name == "buraco")
		{
			texto3.guiText.text = "morreu";
			Destroy(col.gameObject);
			//Destroy (gameObject);
		}
		if(col.gameObject.name == "passaros"){
			
			charac.setMaxSpeed(0.5f);
			Debug.Log ("set speed 2");
			//charac2.trancaPULO();
			colidiuPASSARO = true;
			/*if(bj > 10)
			{
				//charac2.destrancaPULO();
				charac2.trancadoPassaro = false;
				colidiuPASSARO = false;
			}*/

			//resetspeed = true;
		}
		if(col.gameObject.name == "checkpoint"){

			Destroy (col.gameObject);
			manager.salvar = true;
			//salva
		}



	}
	void OnTriggerExit2D(Collider2D col){
		resetspeed = true;
		colidiuPASSARO = false;
		charac2.destrancaPULO();
		
	}
	void OnCollisionEnter2D(Collision2D col){
		//texto2.guiText.text = col.gameObject.name;
		if(col.gameObject.name == "risada(Clone)"){
			//vida -=1;
			Destroy (col.gameObject);
			
		}
		if(col.gameObject.name == "cachorro"){
			//vida -=1;
			if(col.gameObject.transform.position.x > gameObject.transform.position.x){
				npos.x = gameObject.transform.position.x - 1.5f;
				gameObject.rigidbody2D.MovePosition(npos);
			}
			if(col.gameObject.transform.position.x < gameObject.transform.position.x){
				npos.x = gameObject.transform.position.x + 1.5f;
				gameObject.rigidbody2D.MovePosition(npos);

			}
			npos.x = 0;
		}




	}

	//void OnCollisonExit2D(Collision2D col){
		//if(col.gameObject.name == "passaros"){
			//charac.RESETMaxSpeed();
		//}

	//}
	void FixedUpdate (){

	}


}
