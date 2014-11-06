using UnityEngine;
using System.Collections;

public class risada : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject,5.0f);
	
	}

	void OnCollisionEnter2D(Collision2D col){
		//if(col.gameObject.name == "Sofia"){
			//Destroy (gameObject);
		//}
	}
}
