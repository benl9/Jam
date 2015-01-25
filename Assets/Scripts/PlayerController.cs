using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float maxVelocity;
	public float maxJump; 
	public GameObject player;
	bool jump = false;
	public bool deflector = false;  
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(player);
		maxJump = 5; 
		maxVelocity = 5; 
	}
	
	// Update is called once per frame
	void Update () {
		// calculuate x velocity
		float x = Input.GetAxis ("Horizontal") * maxVelocity;
		//calculate y velocity
		float y; 
		if (jump && Input.GetButtonDown ("Jump")) {
			y = maxJump;
		} 
		else {
			y = rigidbody2D.velocity.y;
		}
		// set velocity
		Vector2 velocityP = new Vector2(x,y);
		rigidbody2D.velocity = velocityP;
		
		//make sure sprite is facing the right way
		Vector3 scale = transform.localScale;
		if(x > 0 && scale.x != 1)
			scale.x = 1;
		else if(x < 0 && scale.x != -1)
			scale.x = -1;
		transform.localScale = scale;
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground") {
			//allow player to jump
			jump = true; 
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground") {
			//prevent player from jumping
			jump = false; 
		}
	}
}
