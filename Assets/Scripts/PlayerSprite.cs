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
	public Sprite current; 
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
		status = GetComponent<PlayerStatus>(); 
		spriteMaker = GetComponent<SpriteRenderer>(); 
		current = standingN;
	}
	
	// Update is called once per frame
	void Update () {
		//find sprite needed fot the situation
		Sprite needed; 
		if(status.deflector){
			if(controller.jump){
				if(rigidbody2D.velocity.x == 0){
					needed = standingS;
				}
				else{
					needed = runningS;
				}
			}
			else{
				needed = jumpingS;
			}
		}
		else{
			if(controller.jump){
				if(rigidbody2D.velocity.x == 0){
					needed = standingN;
				}
				else{
					needed = runningN;
				}
			}
			else{
				needed = jumpingN;
			}
		}
		if(current != needed){
			current = needed;
			spriteMaker.sprite = current; 
		}
	}
}
