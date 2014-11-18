using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[RequireComponent(typeof(deposito))]
[RequireComponent(typeof(RBS_main))]

//[RequireComponent(typeof(SaveLoad))]


public class manager : MonoBehaviour
{


	public static bool novo_jogo = true; 
	public static bool salvar = false;
	//public static deposito scene_depo;
	public static int vida_p;
	public static int vida_max_p;
	public static float tempo_de_corda_p;
	public static float corda_max_p;
	public static int fase_p;
	public static string checkpoint_p;
	public static bool next_lvl = false;
	public static int next_lvl_id;
	public static int cont = 0;
	public static bool p_morreu = false;
	public static bool transition = false;
	public static int pos_player = 1;
	public static Vector2 nova_pos;

	//public static bool gerente = false;
	Vector3 pos;
	GameObject lixo;
	GameObject lixo2;


	void Start(){
		//gerente = false;
		pos.x = 0.0f;
		pos.y = 0.0f;
		pos.z = 0.0f;

		
		DontDestroyOnLoad(gameObject);

	}
	
	
	
	void Update()
	{
	

		if(manager.next_lvl == true){
			if(manager.salvar == false){
				lixo = GameObject.FindGameObjectWithTag("gerent");
				lixo2 = GameObject.FindGameObjectWithTag("Player");
				Destroy(lixo2);
				Destroy(lixo);
				manager.cont = 1;
				manager.next_lvl = false;
				Application.LoadLevel(next_lvl_id);
			}
		}
		if(manager.p_morreu == true){
			//Time.timeScale = 0.0f;
		}

	}
	void OnGUI(){
		if(manager.p_morreu == true){
			GUI.Box(new Rect(10,10,100,90), "MORREU");
		
			if(GUI.Button(new Rect(20,40,80,20), "denovo")) {
					lixo = GameObject.FindGameObjectWithTag("gerent");
					Destroy(lixo);
					//manager.novo_jogo = true;
				//Application.LoadLevel("cena01");
				Application.LoadLevel(Application.loadedLevelName);
					manager.p_morreu = false;
					//manager.gerente = false;

					//Time.timeScale = 1.0f;
			//manager.novo_jogo = true;
			
			}
			if(GUI.Button(new Rect(20,70,80,20), "novo jogo")) {
				lixo = GameObject.FindGameObjectWithTag("gerent");
				Destroy(lixo);
				Application.LoadLevel("cena01");
				manager.novo_jogo = true;
				manager.p_morreu = false;
				
			}

		}
	}
	
	
}

