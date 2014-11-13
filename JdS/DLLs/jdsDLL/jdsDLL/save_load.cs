using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//using System.Security.AccessControl;

[RequireComponent(typeof(deposito))]

public class SaveLoad : MonoBehaviour{
	static deposito scene_depoLOADED;
	//public static deposito salvo;

	//it's static so we can call it from anywhere
	public static void Save(deposito aSerSalvo) {
		deposito s = aSerSalvo;
		BinaryFormatter bf = new BinaryFormatter();

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

		}
	}
}

