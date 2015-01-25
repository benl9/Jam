using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public Vector2 spawn;
	public int kills = 0; 
	public int deaths = 0; 
	public bool deflector = false; 
	PlayerController controller;
	public AudioClip[] deathClips = new AudioClip[11];
	// Use this for initialization
	void Start (){ 
		controller = GetComponent<PlayerController>();
	}
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Checkpoint"){
			//change spawn point
			float x = transform.position.x;
			float y = transform.position.y + 1;
			Vector2 respawn = new Vector2(x,y);
			spawn = respawn; 
		}
		else if (collision.gameObject.tag == "HitBox"){
			//destroy the roomba
			DestroyObject (collision.gameObject.transform.parent.gameObject);
			kills++; 
		}
		else if (collision.gameObject.tag == "Death") {
			//return player to spawn point
			transform.position = spawn; 
			deaths ++; 
			if (deaths == 4){	
				controller.maxJump = 10;
				audio.clip = deathClips[8]; 
				audio.Play ();
			}
			else if (deaths == 8){
				controller.maxVelocity = 10;
				audio.clip = deathClips[9]; 
				audio.Play ();
			}
			else if (deaths == 12){
				deflector = true; 
				audio.clip = deathClips[10]; 
				audio.Play ();
			}
			else{
				audio.clip = deathClips[Random.Range(0,7)];
				audio.Play (); 
			}
		} 
		else if (collision.gameObject.tag == "Bullet"){
			//if hit by a bullet...
			if(deflector){
			//reflect bullet
				float x = -collision.gameObject.rigidbody2D.velocity.x;
				float y = -collision.gameObject.rigidbody2D.velocity.y;
				Vector2 velocityB = new Vector2(x,y);
				collision.gameObject.rigidbody2D.velocity = velocityB; 
			}
			else{
			//die
				transform.position = spawn; 
				deaths++; 
				audio.clip = deathClips[Random.Range(0,7)];
				audio.Play (); 
			}
		}
	}
}
