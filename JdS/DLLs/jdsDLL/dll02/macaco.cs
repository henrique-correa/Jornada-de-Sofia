using UnityEngine;
using System.Collections;

public class macaco : MonoBehaviour {
	bool direita = true;
	RaycastHit2D hit;
	RaycastHit2D hit2;
	RaycastHit2D hit3;
	RaycastHit2D hit4;
	int raiolayer;
	Vector2 tirom;
	Vector2 tirom2;
	//float x_macaco;
	//float x_player;
	//float dist;
	//bool pode_atirar = true;
	GameObject banana;
	//Vector2 vel_tiro;
	//Vector2 vel_tiro2;
	float proximo_tiro = 0.0f;
	[SerializeField]float tiro_rate = 50.0f;
	[SerializeField]float distancia_visao_tiro = 5.0f;
	[SerializeField]float tiro_vel = 10.0f;
	[SerializeField]float distancia_visao = 5.0f;
	Animator anim;

	// Use this for initialization
	void Start () {
		//tirom = gameObject.rigidbody2D.transform.position;
		//tiro.x -= 0.5f;
		//tirom2 = gameObject.rigidbody2D.transform.position;
		//tiro2.x += 0.5f;
		//vel_tiro.x = -10.0f;
		//vel_tiro.y = 0.0f;
		//vel_tiro2.x = 10.0f;
		//vel_tiro2.y = 0.0f;
		
		raiolayer = 1 << 8;
		anim = GetComponent<Animator>();
	}


	void FixedUpdate () {

		tirom = gameObject.rigidbody2D.transform.position;
		//tiro.x -= 0.5f;
		tirom2 = gameObject.rigidbody2D.transform.position;

		hit = Physics2D.Raycast(transform.position,-Vector2.right,distancia_visao_tiro,raiolayer);
		hit2 = Physics2D.Raycast(transform.position,Vector2.right,distancia_visao_tiro,raiolayer);
		
		hit3 = Physics2D.Raycast(transform.position,-Vector2.right,distancia_visao,raiolayer);
		hit4 = Physics2D.Raycast(transform.position,Vector2.right,distancia_visao,raiolayer);
		
		
		//Debug.Log (hit.ToString());
		//nome = hit.ToString();
		if (hit.collider != null){
			if(direita == true){
				Flip ();
				direita = false;
			}
			Debug.Log ("inimigo ve o player");
			if(Time.time > proximo_tiro){
				proximo_tiro = Time.time + tiro_rate;
				banana = Instantiate(Resources.Load("risada"),tirom,Quaternion.identity) as GameObject;
				Physics2D.IgnoreCollision (gameObject.rigidbody2D.collider2D,banana.gameObject.rigidbody2D.collider2D);
				anim.SetBool("tiro",true);
				banana.gameObject.rigidbody2D.velocity = new Vector2(-1.0f,0.0f) * tiro_vel;
				anim.SetBool("tiro", false);
			}
			
		}
		if (hit2.collider != null){
			if(direita == false){
				Flip();
				direita = true;
			}
			Debug.Log ("inimigo ve o player");
			if(Time.time > proximo_tiro){
				proximo_tiro = Time.time + tiro_rate;
				banana = Instantiate(Resources.Load("risada"),tirom2,Quaternion.identity) as GameObject;
				Physics2D.IgnoreCollision(gameObject.rigidbody2D.collider2D,banana.gameObject.rigidbody2D.collider2D);
				anim.SetBool("tiro",true);
				banana.gameObject.rigidbody2D.velocity = new Vector2(1.0f,0.0f) * tiro_vel;	
				anim.SetBool("tiro", false);
			}

		}
		if(hit3.collider != null){
			if(direita == true){
				Flip();
				direita = false;
			}
			gameObject.rigidbody2D.velocity = new Vector2(-0.8f, 0.0f);
			anim.SetBool("ve_player", true);
		}

		if(hit4.collider != null){
			if(direita == false){
				Flip();
				direita = true;
			}
			gameObject.rigidbody2D.velocity = new Vector2(0.8f, 0.0f);
			anim.SetBool("ve_player", true);
		}
		if(hit3.collider == null && hit4.collider == null){
			anim.SetBool("ve_player", false);
		}
		
	}

	void OnCollisionEnter2D(Collision col){
		if(col.gameObject.name == "Sofia" || col.gameObject.name == "Sofia(Clone)"){
			anim.SetBool("soco", true);
		}
		anim.SetBool("soco", false);

	}

	void Flip ()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
