using UnityEngine;
using System.Collections;

public class macaco : MonoBehaviour {

	RaycastHit2D hit;
	RaycastHit2D hit2;
	RaycastHit2D hit3;
	RaycastHit2D hit4;
	int raiolayer;
	Vector2 tirom;
	Vector2 tirom2;
	float x_macaco;
	float x_player;
	float dist;
	//bool pode_atirar = true;
	GameObject banana;
	Vector2 vel_tiro;
	Vector2 vel_tiro2;
	float proximo_tiro = 0.0f;
	[SerializeField]float tiro_rate = 50.0f;
	[SerializeField]float distancia_visao = 5.0f;
	[SerializeField]float tiro_vel = 10.0f;
	
	// Use this for initialization
	void Start () {
		//tirom = gameObject.rigidbody2D.transform.position;
		//tiro.x -= 0.5f;
		//tirom2 = gameObject.rigidbody2D.transform.position;
		//tiro2.x += 0.5f;
		vel_tiro.x = -10.0f;
		vel_tiro.y = 0.0f;
		vel_tiro2.x = 10.0f;
		vel_tiro2.y = 0.0f;
		
		raiolayer = 1 << 8;
	}


	void FixedUpdate () {

		tirom = gameObject.rigidbody2D.transform.position;
		//tiro.x -= 0.5f;
		tirom2 = gameObject.rigidbody2D.transform.position;

		hit = Physics2D.Raycast(transform.position,-Vector2.right,distancia_visao,raiolayer);
		hit2 = Physics2D.Raycast(transform.position,Vector2.right,distancia_visao,raiolayer);
		
		hit3 = Physics2D.Raycast(transform.position,-Vector2.right,10.0f,raiolayer);
		hit4 = Physics2D.Raycast(transform.position,Vector2.right,10.0f,raiolayer);
		
		
		//Debug.Log (hit.ToString());
		//nome = hit.ToString();
		if (hit.collider != null){
			Debug.Log ("inimigo ve o player");
			if(Time.time > proximo_tiro){
				proximo_tiro = Time.time + tiro_rate;
				banana = Instantiate(Resources.Load("risada"),tirom,Quaternion.identity) as GameObject;
				Physics2D.IgnoreCollision (gameObject.rigidbody2D.collider2D,banana.gameObject.rigidbody2D.collider2D);
				//ris.rigidbody2D.AddRelativeForce(vel_tiro);
				//ris.gameObject.rigidbody2D.AddRelativeForce(vel_tiro);
				banana.gameObject.rigidbody2D.velocity = new Vector2(-1.0f,0.0f) * tiro_vel;
				

				//pode_atirar = false;
			}
			
		}
		if (hit2.collider != null){
			Debug.Log ("inimigo ve o player");
			if(Time.time > proximo_tiro){
				proximo_tiro = Time.time + tiro_rate;
				banana = Instantiate(Resources.Load("risada"),tirom2,Quaternion.identity) as GameObject;
				Physics2D.IgnoreCollision(gameObject.rigidbody2D.collider2D,banana.gameObject.rigidbody2D.collider2D);
				//ris.rigidbody2D.AddRelativeForce(vel_tiro);
				//ris.gameObject.rigidbody2D.AddRelativeForce(vel_tiro2);
				banana.gameObject.rigidbody2D.velocity = new Vector2(1.0f,0.0f) * tiro_vel;
				
				
				//pode_atirar = false;
			}

		}
		if(hit3.collider != null){
			if(gameObject.rigidbody2D.transform.position.x < 0){
				x_macaco = gameObject.rigidbody2D.transform.position.x * -1;

			}
			if(hit3.collider.transform.position.x < 0){
				x_player = hit3.collider.transform.position.x * -1;

			}
			dist = x_macaco - x_player;

			if(dist < 0){
				dist = dist * -1;
			}
			if(dist > 1.6){
				gameObject.rigidbody2D.velocity = new Vector2(-0.8f, 0.0f);
			}

		}

		if(hit4.collider != null){
			if(gameObject.rigidbody2D.transform.position.x < 0){
				x_macaco = gameObject.rigidbody2D.transform.position.x * -1;
				Debug.Log ("x macaco" + x_macaco);
			}
			if(hit4.collider.transform.position.x < 0){
				x_player = hit3.collider.transform.position.x * -1;
				Debug.Log ("x player" + x_player);
			}
			dist = x_player - x_macaco;
			if(dist < 0){
				dist = dist * -1;
			}
			Debug.Log ("distancia" + dist);
			if(dist < 1.6){
				gameObject.rigidbody2D.velocity = new Vector2(0.8f, 0.0f);
			}
			
		}
		
	}
}
