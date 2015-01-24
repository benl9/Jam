using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Vector2 spawn;
	public float maxVelocity;
	public float maxJump; 
	public GameObject player; 
	bool jump = false; 
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(player);
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
			jump = true; 
		} 
		else if (collision.gameObject.tag == "HitBox"){
			Debug.Log ("Something");
			DestroyObject (collision.gameObject.transform.parent.gameObject);
		}
		else if (collision.gameObject.tag == "Death") {
			transform.position = spawn; 
		}	
	}
	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground") {
			jump = false; 
		}
	}
}
