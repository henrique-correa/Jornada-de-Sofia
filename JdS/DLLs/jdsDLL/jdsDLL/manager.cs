using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[RequireComponent(typeof(deposito))]
//[RequireComponent(typeof(SaveLoad))]

public class manager : MonoBehaviour
{
	
	public static bool novo_jogo; 
	public static bool salvar = false;
	public static deposito scene_depo;

	void Start(){
		
		
		
		DontDestroyOnLoad(gameObject);
	}
	
	
	
	void Update()
	{

		
		
	}
	
	
}

