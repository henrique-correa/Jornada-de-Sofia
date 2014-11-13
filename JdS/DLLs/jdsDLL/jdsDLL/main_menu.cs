using UnityEngine;


[RequireComponent(typeof(manager))]
[RequireComponent(typeof(SaveLoad))]

public class menu : MonoBehaviour
{

void OnGUI(){
	GUI.Box(new Rect(10,10,100,90), "Loader Menu");
	
	// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
	if(GUI.Button(new Rect(20,40,80,20), "novo jogo")) {
		Application.LoadLevel("cena01");
			//manager.novo_jogo = true;
		
	}
	
	// Make the second button.
	if(GUI.Button(new Rect(20,70,80,20), "continuar")) {
			manager.fase_p = SaveLoad.LoadLevel();
			Application.LoadLevel(manager.fase_p);
			manager.novo_jogo = false;
			//manager.cont = 1;

		//carrega a fase que estra no salvo
	}
	
	
}
}
