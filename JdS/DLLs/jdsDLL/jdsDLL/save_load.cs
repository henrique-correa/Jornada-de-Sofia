using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//using System.Globalization;
//using System.Security.AccessControl;

[RequireComponent(typeof(deposito))]
//[RequireComponent(typeof(lista_fase))]


public class SaveLoad {

<<<<<<< HEAD


	public static void Save(List<GameObject> aSerSalvo) {
		 
		StreamWriter r;
		r = File.CreateText("E:/salvoUNITY/save.sg");
		string linha = "#tipo    x     y     vida     vida_max     corda     corda_max     fase     checkpoint";
		r.WriteLine(linha);
		for(int i=0; i < aSerSalvo.Count ;i++){
			if(aSerSalvo[i].tag == "Player"){
				linha = aSerSalvo[i].name + " " + 
						aSerSalvo[i].transform.position.x.ToString("0.00") + " " + 
						aSerSalvo[i].transform.position.y.ToString("0.00") + " " + 
						manager.vida_p + " " +
						manager.vida_max_p + " " +
						manager.tempo_de_corda_p + " " +
						manager.corda_max_p + " " +
						manager.fase_p + " " +
						manager.checkpoint_p;

			}
			else{
			linha = aSerSalvo[i].name + " " + 
				aSerSalvo[i].transform.position.x.ToString("0.00") + " " + 
				aSerSalvo[i].transform.position.y.ToString("0.00") + " " + 
				"null" + " " + 
				"null" + " " + 
				"null" + " " + 
				"null" + " " + 
				"null" + " " + 
				"null";
			}
			r.WriteLine(linha);
		}
		r.Close();
	}   
	
	public static List<deposito> Load(string caminho) {
		List<deposito> scene_depoLOADED = new List<deposito>{};//new List<deposito>();

		StreamReader r;
		if(File.Exists(caminho)) {
			string linha;
			r = File.OpenText(caminho);
			linha = r.ReadLine();

			
			while(r.EndOfStream == false){

				deposito temp = new deposito{};// = new deposito();
				linha = r.ReadLine();
				string[] l =  linha.Split(' ');

				if( l[0] == "Sofia"){ 
					//Debug.Log ("entrou no LOAD");
					temp.tipo = l[0];
					temp.x = float.Parse ( l[1] );
					temp.y = float.Parse( l[2] );
					temp.vida = int.Parse( l[3] );
					temp.vida_max = int.Parse( l[4] );
					temp.tempo_de_corda = float.Parse( l[5] );
					temp.corda_max = float.Parse( l[6] );
					temp.fase = int.Parse( l[7] );
					temp.checkpoint = int.Parse( l[8] );
					scene_depoLOADED.Add(temp);
					//Debug.Log ("entrou no LOAD if")
				}
				else{
					//Debug.Log ("entrou no LOAD else");
					temp.tipo = l[0];
					temp.x = float.Parse( l[1] );
					temp.y = float.Parse( l[2] );
					scene_depoLOADED.Add(temp);
				}
=======
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream f = File.Create ("G:/Familia Silva/Frederico/Estudos/Curso Jogos Digitais/Terceiro semestre/Projeto de Motores/ProjetoGitHub/save.sg"); //you can call it anything you want
		bf.Serialize(f, s);
		f.Close();
	}   
	
	public static void Load() {
		if(File.Exists("G:/Familia Silva/Frederico/Estudos/Curso Jogos Digitais/Terceiro semestre/Projeto de Motores/ProjetoGitHub/save.sg")) {
			BinaryFormatter bfl = new BinaryFormatter();
			FileStream fl = File.Open("G:/Familia Silva/Frederico/Estudos/Curso Jogos Digitais/Terceiro semestre/Projeto de Motores/ProjetoGitHub/save.sg", FileMode.Open);
			scene_depoLOADED = (deposito)bfl.Deserialize(fl);
			fl.Close();
>>>>>>> origin/master

				Debug.Log(scene_depoLOADED[0].x);
			}
			r.Close();
		}
		return scene_depoLOADED;
	}

	public static void SaveLevel(){
		StreamWriter r;
		r = File.CreateText("E:/salvoUNITY/ll.ll");
		string linha;
		linha = Application.loadedLevel.ToString();
		r.WriteLine(linha);
		r.Close();
	}

	public static int LoadLevel(){
		int lvl = 0;
		if(File.Exists("E:/salvoUNITY/ll.ll")){
			StreamReader r;
			r = File.OpenText("E:/salvoUNITY/ll.ll");
			string linha;
			linha = r.ReadLine();
			lvl = int.Parse(linha);
			r.Close();
		}
		return lvl;		
	}


}

