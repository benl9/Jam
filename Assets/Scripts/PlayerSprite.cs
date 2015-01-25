using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {

	PlayerStatus status; 
	PlayerController controller;
	SpriteRenderer spriteMaker; 
	public Sprite standingN; 
	public Sprite standingS;
	public Sprite runningN;
	public Sprite runningS;
	public Sprite jumpingN;
	public Sprite jumpingS;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
		status = GetComponent<PlayerStatus>(); 
		spriteMaker = GetComponent<SpriteRenderer>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if(status.deflector){
			if(controller.jump){
				if(rigidbody2D.velocity.x == 0){
					spriteMaker.sprite = standingS;
				}
				else{
					spriteMaker.sprite = runningS;
				}
			}
			else{
				spriteMaker.sprite = jumpingS;
			}
		}
		else{
			if(controller.jump){
				if(rigidbody2D.velocity.x == 0){
					spriteMaker.sprite = standingN;
				}
				else{
					spriteMaker.sprite = runningN;
				}
			}
			else{
				spriteMaker.sprite = jumpingN;
			}
		}
	}
}
