using UnityEngine;
using System.Collections;

public class inimigo_cachorro : MonoBehaviour {
	bool direita = true;
	RaycastHit2D hit;
	RaycastHit2D hit2;
	[SerializeField]float distancia = 2.0f;
	[SerializeField]float ini_velo = 5.0f;
	Animator anim;
	//int id;

	int raylayer;
	// Use this for initialization
	void Start () {

		raylayer = 1 << 8;
		anim = GetComponent<Animator>();


	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//esquerda = transform.TransformDirection(-Vector2.right);
		hit = Physics2D.Raycast(transform.position,-Vector2.right,distancia,raylayer);

		hit2 = Physics2D.Raycast(transform.position,Vector2.right,distancia,raylayer);
		//Debug.Log (hit.ToString());
		//nome = hit.ToString();
		if (hit.collider != null){
			Debug.Log ("inimigo ve o player");
			//rigidbody2D.AddForce(esquerda);
			if(direita == true){
				Flip();
				direita = false;
			}
			anim.SetBool ("VE_player",true);
			rigidbody2D.velocity = new Vector2(-1,0) * ini_velo;
		}

		if (hit2.collider != null){
			Debug.Log ("inimigo ve o player");
			//rigidbody2D.AddForce(direita);
			if(direita == false){
				Flip();
				direita = true;
			}
			anim.SetBool ("VE_player",true);
			rigidbody2D.velocity = new Vector2(1,0) * ini_velo;
		}
		if(hit.collider == null && hit2.collider == null){
			anim.SetBool ("VE_player",false);
		}

					
	
	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Sofia"){
			//col.gameObject.rigidbody2D.AddForce(push);
		}
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

