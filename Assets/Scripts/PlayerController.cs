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
		float x = Input.GetAxis ("Horizontal") * maxVelocity;
		float y; 
		if (jump && Input.GetButtonDown ("Jump")) {
			y = maxJump;
		} 
		else {
			y = rigidbody2D.velocity.y;
		}
		Vector2 velocityP = new Vector2(x,y);
		rigidbody2D.velocity = velocityP; 
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground") {
			jump = true; 
		} 
		else if (collision.gameObject.tag == "Spikes") {
			transform.position = spawn; 
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground") {
			jump = false; 
		}
	}
}
