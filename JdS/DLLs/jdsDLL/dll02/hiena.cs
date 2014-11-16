﻿using UnityEngine;
using System.Collections;

public class hiena : MonoBehaviour {
	bool esquerda = true;
	bool movendo = false;
	RaycastHit2D hit;
	RaycastHit2D hit2;
	RaycastHit2D hit3;
	RaycastHit2D hit4;
	int raiolayer;
	Vector2 tiro;
	Vector2 tiro2;
	//bool pode_atirar = true;
	GameObject ris;
	Vector2 vel_tiro;
	Vector2 vel_tiro2;
	float proximo_tiro = 0.0f;
	[SerializeField]float tiro_rate = 50.0f;
	[SerializeField]float distancia_visao = 5.0f;
	[SerializeField]float tiro_vel = 10.0f;
	Animator anim;

	// Use this for initialization
	void Start () {
		//tiro = transform.position;
		//tiro.x -= 0.5f;
		//tiro2 = transform.position;
		//tiro2.x += 0.5f;
		vel_tiro.x = -10.0f;
		vel_tiro.y = 0.0f;
		vel_tiro2.x = 10.0f;
		vel_tiro2.y = 0.0f;
	
		raiolayer = 1 << 8;

		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		tiro = transform.position;
		//tiro.x -= 0.5f;
		tiro2 = transform.position;

		hit = Physics2D.Raycast(transform.position,-Vector2.right,distancia_visao,raiolayer);
		hit2 = Physics2D.Raycast(transform.position,Vector2.right,distancia_visao,raiolayer);

		hit3 = Physics2D.Raycast(transform.position,-Vector2.right,4.0f,raiolayer);
		hit4 = Physics2D.Raycast(transform.position,Vector2.right,4.0f,raiolayer);
		
		
		//Debug.Log (hit.ToString());
		//nome = hit.ToString();
		if (hit.collider != null){
			if(movendo == false){
				if(esquerda == false){
					Flip();
					esquerda = true;
				}
			}
			Debug.Log ("inimigo ve o player");

			if(Time.time > proximo_tiro){
				proximo_tiro = Time.time + tiro_rate;
				ris = Instantiate(Resources.Load("risada"),tiro,Quaternion.identity) as GameObject;
				Physics2D.IgnoreCollision (gameObject.rigidbody2D.collider2D,ris.gameObject.rigidbody2D.collider2D);
				//ris.rigidbody2D.AddRelativeForce(vel_tiro);
				//ris.gameObject.rigidbody2D.AddRelativeForce(vel_tiro);
				ris.gameObject.rigidbody2D.velocity = new Vector2(-1.0f,0.0f) * tiro_vel;



				//pode_atirar = false;
			}

		}
		if (hit2.collider != null){
			if(movendo == false){
				if(esquerda == true){
					Flip();
					esquerda = false;
				}
			}
			Debug.Log ("inimigo ve o player");
			if(Time.time > proximo_tiro){
				proximo_tiro = Time.time + tiro_rate;
				ris = Instantiate(Resources.Load("risada"),tiro2,Quaternion.identity) as GameObject;
				Physics2D.IgnoreCollision (gameObject.rigidbody2D.collider2D,ris.gameObject.rigidbody2D.collider2D);
				//ris.rigidbody2D.AddRelativeForce(vel_tiro);
				//ris.gameObject.rigidbody2D.AddRelativeForce(vel_tiro2);
				ris.gameObject.rigidbody2D.velocity = new Vector2(1.0f,0.0f) * tiro_vel;

				
				//pode_atirar = false;
			}
			
		}
		if(hit3.collider != null){
			movendo = true;
			rigidbody2D.velocity = new Vector2(0.8f, 0.0f);

				if(esquerda == true){
					Flip();
					esquerda = false;
				}

			anim.SetBool("ve_player", true);

		}
		if(hit4.collider != null){
			movendo = true;
			rigidbody2D.velocity = new Vector2(-0.8f, 0.0f);
			if(esquerda == false){
				Flip();
				esquerda = true;
			}
			anim.SetBool("ve_player", true);
		}

		if(hit3.collider == null && hit4.collider == null){
			movendo = false;
			anim.SetBool ("ve_player",false);
		}
	
	}
	void OnTriggerEnter2D(Collider2D col){

	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		//facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
