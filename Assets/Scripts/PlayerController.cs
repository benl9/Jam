using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Vector2 spawn;
	public float maxVelocity;
	public float maxJump; 
	public GameObject player; 
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(player);
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal") * maxVelocity;
		float y = Input.GetButtonDown ("Jump") ? maxJump : rigidbody2D.velocity.y;
		Vector2 velocityP = new Vector2(x,y);
		rigidbody2D.velocity = velocityP; 
	}
	void OnCollisionEnter2D(Collision2D collision){
		maxJump = 10; 
	}
	void OnCollisionExit2D(Collision2D collision){
		maxJump = 0; 
	}
}
