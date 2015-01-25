using UnityEngine;
using System.Collections;

public class KamikazeAI : MonoBehaviour {

	Transform player;
	public Transform target; 
	public float speed;


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
		if(Mathf.Abs (enemyX - playerX) <= 3) {
			target.rigidbody2D.gravityScale = speed;

		}
	}

}