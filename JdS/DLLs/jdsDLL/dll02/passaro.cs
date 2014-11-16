using UnityEngine;
using System.Collections;

public class passaro : MonoBehaviour {
	bool direita = true;
	RaycastHit2D hitp;
	RaycastHit2D hitp2;
	[SerializeField]float distancia = 2.0f;
	[SerializeField]float ini_velo = 0.5f;
	//int id;
	Animator anim;
	int raylayer;
	// Use this for initialization
	void Start () {
		raylayer = 1 << 8;
		anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		hitp = Physics2D.Raycast(transform.position,-Vector2.right,distancia,raylayer);
		
		hitp2 = Physics2D.Raycast(transform.position,Vector2.right,distancia,raylayer);

		if (hitp.collider != null){
			if(direita == true){
				Flip ();
				direita = false;
			}
			Debug.Log ("passaro inimigo ve o player");
			anim.SetBool("ve_player", true);
			rigidbody2D.velocity = new Vector2(-1,0) * ini_velo;
		}



		if (hitp2.collider != null){
			if(direita == false){
				Flip ();
				direita = true;
			}
			Debug.Log ("passaro inimigo ve o player");
			anim.SetBool("ve_player", true);
			rigidbody2D.velocity = new Vector2(1,0) * ini_velo;
		
		}

		if(hitp.collider == null && hitp2.collider == null){
			anim.SetBool("ve_player", false);
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

