using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[RequireComponent(typeof(deposito))]
[RequireComponent(typeof(manager))]
[RequireComponent(typeof(SaveLoad))]

public class gerente : MonoBehaviour
{

	Vector3 pos = new Vector3(2.80f, 0.40f, 0.0f);
	Vector3 pos_p = new Vector3(-2.29f, 0.48f, 0.0f);
	//bool novo_jogo = true;
	GameObject npc;
	GameObject p;
	//deposito scene_depo;
	//manager m;



	void criar_scene(){
		//AI director ve quais os parametros para criar os objetos da scene
		if(manager.novo_jogo == true){

				
				p = Instantiate(Resources.Load("Sofia"), pos_p, Quaternion.identity) as GameObject;
				//scene_depo.jog = p;
			npc = Instantiate(Resources.Load("cachorro"), pos, Quaternion.identity) as GameObject;
			//scene_depo.inimigos.Add(npc);
			manager.novo_jogo = false;

				//instacia todos da primeira fase

		}
		else if(manager.novo_jogo == false){
			//SaveLoad.Load();//carrega os inimigos do aruivo referente da fase(qual fase e qual nivel de dificuldade)
		}

	}

	void Start(){

		criar_scene();

		//DontDestroyOnLoad(gameObject);
	}



	void Update()
	{
		if(manager.salvar == true){
			SaveLoad.Save(manager.scene_depo);
			manager.salvar = false;
		}
		/*if(Application.loadedLevelName != "menu_principal"){
			if(carregar == true)
			{
				//criar_scene();
				carregar = false;
			}
			
			Debug.Log(carregar);
		}*/
		//Debug.Log (scene_deposito.inimigos.Count);
	}


}
