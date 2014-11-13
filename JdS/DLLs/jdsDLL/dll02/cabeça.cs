using UnityEngine;
using System.Collections;

public class cabeça : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Destroy(transform.parent.gameObject);

			Debug.Log("cabeça");
		}

	}
}
