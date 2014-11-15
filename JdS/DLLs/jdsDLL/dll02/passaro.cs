﻿using UnityEngine;
using System.Collections;

public class passaro : MonoBehaviour {
	RaycastHit2D hitp;
	RaycastHit2D hitp2;
	[SerializeField]float distancia = 2.0f;
	[SerializeField]float ini_velo = 0.5f;
	//int id;
	
	int raylayer;
	// Use this for initialization
	void Start () {
		raylayer = 1 << 8;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		hitp = Physics2D.Raycast(transform.position,-Vector2.right,distancia,raylayer);
		
		hitp2 = Physics2D.Raycast(transform.position,Vector2.right,distancia,raylayer);

		if (hitp.collider != null){
			Debug.Log ("passaro inimigo ve o player");
			//rigidbody2D.AddForce(esquerda);
			rigidbody2D.velocity = new Vector2(-1,0) * ini_velo;
		}



		if (hitp2.collider != null){
			Debug.Log ("passaro inimigo ve o player");
			//rigidbody2D.AddForce(direita);
			rigidbody2D.velocity = new Vector2(1,0) * ini_velo;
		
		}
	
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Sofia"){
		//col.gameObject.rigidbody2D.AddForce(push);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.name == "Sofia" || col.gameObject.name == "Sofia(Clone)"){
			Debug.Log ("SAIU DA COLISAO");
			rigidbody2D.velocity = new Vector2(-1,0) * 20;
			Destroy (gameObject, 3);
			//col.gameObject.rigidbody2D.AddForce(push);
		}
	}
}

