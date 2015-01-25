using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Vector2 spawn;
	public float maxVelocity;
	public float maxJump; 
	public GameObject player;
	public int kills = 0; 
	public int deaths = 0;  
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
			jump = true; 
		}
		else if(collision.gameObject.tag == "Checkpoint"){
			float x = transform.position.x;
			float y = transform.position.y + 3;
			Vector2 respawn = new Vector2(x,y);
			spawn = respawn; 
		}
		else if (collision.gameObject.tag == "HitBox"){
			DestroyObject (collision.gameObject.transform.parent.gameObject);
			kills ++; 
		}
		else if (collision.gameObject.tag == "Death") {
			transform.position = spawn; 
			deaths ++; 
			if (deaths == 4){	
				maxJump = 10;
			}
			else if (deaths == 8){
				maxVelocity = 10;
			}
			else if (deaths == 12){
				deflector = true; 
			}
		} 	
	}
	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground") {
			jump = false; 
		}
	}
}
