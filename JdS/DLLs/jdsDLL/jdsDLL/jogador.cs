using UnityEngine;
using System.Collections;


[RequireComponent(typeof(PlatformerCharacter2D))]
[RequireComponent(typeof(Platformer2DUserControl))]
[RequireComponent(typeof(manager))]

public class jogador : MonoBehaviour {

	[SerializeField]float tempo_de_corda =900.0f;
	[SerializeField]int vida = 3;
	[SerializeField]float corda_max = 1000.0f;
	[SerializeField]int vida_max = 5;
	Vector2 np;
	Vector2 npos;
	GameObject texto;
	//GameObject texto2;
	//GameObject texto3;
	bool resetspeed = false;
	[SerializeField]int bj = 0;
	[SerializeField]bool colidiuPASSARO = false;

	PlatformerCharacter2D charac;
	Platformer2DUserControl charac2;

	// Use this for initialization
	void Start () {
		texto = GameObject.Find("debug_1");
		//texto2 = GameObject.Find("debug_2");
		//texto3 = GameObject.Find("debug_3");

		if(manager.cont == 1){
			vida_max = manager.vida_max_p;
			vida = manager.vida_max_p;
			corda_max = manager.corda_max_p;
			tempo_de_corda = manager.corda_max_p;
		}

		charac = GetComponent<PlatformerCharacter2D>();
		charac2 = GetComponent<Platformer2DUserControl>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(tempo_de_corda > 0){
			tempo_de_corda -= 1.0f;
		//if (tempo_de_corda < 1.0f){
		}
		if(colidiuPASSARO == true){
			Debug.Log("entrou BJ2");
			charac2.trancadoPassaro = true;
			if(Input.GetButtonDown("Jump")){
				Debug.Log("entrou BJ");
				bj++;
			}
		}
		if(bj >= 10){
			
			charac2.trancadoPassaro = false;
			colidiuPASSARO = false;
			bj = 0;
		}

		if(resetspeed == true){
			charac.RESETMaxSpeed();
			resetspeed = false;
		}
		//texto.guiText.text = tempo_de_corda.ToString("0.0");
		if(tempo_de_corda <= 0){
			//texto.guiText.text = "gameover";

		}
		if(vida <=0){
			//manager.p_morreu = true;
			//Destroy(gameObject);
		}

		/*if(vida <=0){
			manager.p_morreu = true;
			Destroy(gameObject);
		}*/
		 

	
	}
	void OnTriggerEnter2D(Collider2D col){

		//texto2.guiText.text = col.gameObject.name;
		if(col.gameObject.name == "chave_de_corda"){
			tempo_de_corda += 100.0f;
			if(tempo_de_corda > corda_max)
			{
				tempo_de_corda = corda_max;
			}
			Destroy(col.gameObject);
			//Debug.Log("colidiu");
			}
		if(col.gameObject.name == "buraco")
		{
			//texto3.guiText.text = "morreu";
			Destroy(col.gameObject);
			//Destroy (gameObject);
		}
		if(col.gameObject.name == "passaros" || col.gameObject.name == "passaros(Clone)"){
			
			charac.setMaxSpeed(0.5f);
			//charac2.trancadoPassaro = true;
			//Debug.Log ("set speed 2");
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
		if(col.gameObject.tag == "check_point"){
			manager.vida_p = vida;
			manager.vida_max_p = vida_max;
			manager.tempo_de_corda_p = tempo_de_corda;
			manager.corda_max_p = corda_max;
			manager.checkpoint_p = col.gameObject.name;
			//SaveLoad.Save(manager.scene_depo);
			Destroy (col.gameObject);
			manager.salvar = true;
			//salva
		}
		if(col.gameObject.name == "cave_transition_01"){
			manager.vida_p = vida;
			manager.vida_max_p = vida_max;
			manager.tempo_de_corda_p = tempo_de_corda;
			manager.corda_max_p = corda_max;


			manager.next_lvl_id = 2;
			//manager.nova_pos = 1;
			//manager.next_lvl = true;
			manager.next_lvl = true;
			manager.salvar = true;

		}

		if(col.gameObject.name == "cave_transition_02"){
			manager.vida_p = vida;
			manager.vida_max_p = vida_max;
			manager.tempo_de_corda_p = tempo_de_corda;
			manager.corda_max_p = corda_max;
			
			
			manager.next_lvl_id = 2;
			manager.pos_player = 2;
			//manager.nova_pos = 1;
			//manager.next_lvl = true;
			manager.next_lvl = true;
			manager.salvar = true;
			
		}
		if(col.gameObject.name == "sky_transition_01"){
			manager.vida_p = vida;
			manager.vida_max_p = vida_max;
			manager.tempo_de_corda_p = tempo_de_corda;
			manager.corda_max_p = corda_max;
			
			
			manager.next_lvl_id = 3;
			//manager.pos_player = 2;
			//manager.nova_pos = 1;
			//manager.next_lvl = true;
			manager.next_lvl = true;
			manager.salvar = true;
			
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
		if(col.gameObject.name == "cachorro(Clone)" || col.gameObject.name == "cachorro"){
			vida -=1;
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

		if(col.gameObject.name == "macaco(Clone)" || col.gameObject.name == "macaco"){
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

		if(col.gameObject.name == "rato(Clone)" || col.gameObject.name == "rato"){
			//GameObject.Find("checkpoint_0"+)

			np.x = 1000.0f;
			GameObject[] ck = GameObject.FindGameObjectsWithTag("check_point");
			for(int i =0;i< ck.Length;i++){
				if(ck[i].transform.position.x > gameObject.transform.position.x){
					if(ck[i].transform.position.x < np.x){
						np.x = ck[i].transform.position.x;
						np.y = ck[i].transform.position.y;
					}
				}

			}
			gameObject.rigidbody2D.position = np;
			//gameObject.rigidbody2D.MovePosition(np);
		}




	}

	//void OnCollisonExit2D(Collision2D col){
		//if(col.gameObject.name == "passaros"){
			//charac.RESETMaxSpeed();
		//}

	//}
	void FixedUpdate (){

	}

	public float get_temp_corda(){
		return tempo_de_corda;
	}
	public int get_vida(){
		return vida;
	}


}
