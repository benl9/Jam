using UnityEngine;
using System.Collections;

public class KamikazeAI : MonoBehaviour {

	Transform player;
	public Transform target; 
	public float speed;
	public float maxJump;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;

		//enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		float enemyX = target.transform.position.x;
		float playerX = player.position.x; 
		float enemyY = target.transform.position.y;
		float playerY = player.transform.position.y;

		if ((enemyY - playerY) <= maxJump) {
			if (Mathf.Abs (enemyX - playerX) <= 3) {
				target.rigidbody2D.gravityScale = speed;

			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground") {
			Destroy (transform.gameObject);
		}
	}

}