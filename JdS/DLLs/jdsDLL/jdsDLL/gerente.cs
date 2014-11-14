using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

[RequireComponent(typeof(deposito))]
[RequireComponent(typeof(manager))]
[RequireComponent(typeof(SaveLoad))]

public class gerente : MonoBehaviour
{

	//GameObject npc1;
	//GameObject npc2;
	public List<GameObject> obj_list;
	public List<deposito> scene_depo;

	void criar_scene() {
		//AI director ve quais os parametros para criar os objetos da scene
		if(manager.novo_jogo == true) {
			scene_depo = SaveLoad.Load("Assets/data_base/fase_01.txt");
			/*Debug.Log(scene_depo[0].tipo);
			Debug.Log (scene_depo[1].tipo);
			
			for(int i=0; i < 3; i++){
				if(scene_depo[i].tipo == "Sofia" || scene_depo[i].tipo == "Sofia(Clone)"){
					Vector3 pos;
					pos.x = scene_depo[i].x;
					pos.y = scene_depo[i].y;
					pos.z = 1.0f;
					manager.vida_p = scene_depo[i].vida;
					manager.vida_max_p = scene_depo[i].vida_max;
					manager.tempo_de_corda_p = scene_depo[i].tempo_de_corda;
					manager.corda_max_p = scene_depo[i].corda_max;
					
					npc = Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject;
					obj_list.Add(npc);
					Debug.Log ("entrou no FOR do NOVO JOGO cria_scene");
				}
				else{
					Vector3 pos;
					pos.x = scene_depo[i].x;
					pos.y = scene_depo[i].y;
					pos.z = 1.0f;
					//Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject;
					obj_list.Add(Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject);
				}
			}*/
		}
		else if (manager.cont == 0){
			scene_depo = SaveLoad.Load("Assets/salvo/save.sg");

			/*for(int i=0; i < scene_depo.Count; i++){
				if(scene_depo[i].tipo == "Sofia(Clone)" || scene_depo[i].tipo == "Sofia"){
					Vector3 pos;
					pos.x = scene_depo[i].x;
					pos.y = scene_depo[i].y;
					pos.z = 1.0f;
					manager.vida_p = scene_depo[i].vida;
					manager.vida_max_p = scene_depo[i].vida_max;
					manager.tempo_de_corda_p = scene_depo[i].tempo_de_corda;
					manager.corda_max_p = scene_depo[i].corda_max;
					
					//npc = Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject;
					obj_list.Add(Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject);
					Debug.Log ("entrou no FOR do CARREGA cria_scene");
				}
				else{
					Vector3 pos;
					pos.x = scene_depo[i].x;
					pos.y = scene_depo[i].y;
					pos.z = 1.0f;
					//npc = Instantiate(Resources.Load(scene_depo[i].tipo+"clone"), pos ,Quaternion.identity) as GameObject;
					obj_list.Add(Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject);
				}
			}*/
		}
		else if(manager.cont == 1){
			string n = manager.next_lvl_id.ToString();
			scene_depo = SaveLoad.Load("Assets/data_base/fase_0"+ n +".txt");
			
			/*for(int i=0; i < scene_depo.Count; i++){
				if(scene_depo[i].tipo == "Sofia(Clone)" || scene_depo[i].tipo == "Sofia"){
					Vector3 pos;
					pos.x = scene_depo[i].x;
					pos.y = scene_depo[i].y;
					pos.z = 1.0f;
					manager.vida_p = scene_depo[i].vida;
					manager.vida_max_p = scene_depo[i].vida_max;
					manager.tempo_de_corda_p = scene_depo[i].tempo_de_corda;
					manager.corda_max_p = scene_depo[i].corda_max;

					npc = Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject;
					obj_list.Add(npc);
					Debug.Log ("entrou no FOR do CARREGA2 cria_scene");
				}
				else{
					Vector3 pos;
					pos.x = scene_depo[i].x;
					pos.y = scene_depo[i].y;
					pos.z = 1.0f;
					npc = Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject;
					obj_list.Add(npc);
				}
			}*/

		}

		for(int i=0; i < scene_depo.Count; i++){
			if(scene_depo[i].tipo == "Sofia(Clone)" || scene_depo[i].tipo == "Sofia"){
				scene_depo[i].tipo = "Sofia";
				Vector3 pos;
				pos.x = scene_depo[i].x;
				pos.y = scene_depo[i].y;
				pos.z = 1.0f;
				manager.vida_p = scene_depo[i].vida;
				manager.vida_max_p = scene_depo[i].vida_max;
				manager.tempo_de_corda_p = scene_depo[i].tempo_de_corda;
				manager.corda_max_p = scene_depo[i].corda_max;
				GameObject cp = GameObject.Find(manager.checkpoint_p);
				Destroy(cp);
				
				//npc1 = 

				obj_list.Add(Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity) as GameObject);
				Debug.Log ("entrou no FOR do CARREGA2 cria_scene");
			}
			else{
				if(scene_depo[i].tipo == "cachorro(Clone)"){scene_depo[i].tipo = "cachorro";}
				Vector3 pos;
				pos.x = scene_depo[i].x;
				pos.y = scene_depo[i].y;
				pos.z = 1.0f;
				//npc2 = 

				obj_list.Add(Instantiate(Resources.Load(scene_depo[i].tipo), pos ,Quaternion.identity)as GameObject );
			}
		}




	}

	void Start(){
		criar_scene();
		manager.fase_p = Application.loadedLevel;
		//Debug.Log(Application.persistentDataPath);
	}



	void Update()
	{
		//Debug.Log ("tamanho de inimigos"+ scene_depo.inimigos.Count);
		if(manager.salvar == true){
			obj_list.RemoveAll(item => item == null);
			SaveLoad.Save(obj_list);
			SaveLoad.SaveLevel();
			manager.salvar = false;
			manager.novo_jogo = false;

		}

	}
}
