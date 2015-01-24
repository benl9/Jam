using UnityEngine;
using System.Collections;

public class RoombaBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (Random.Range(0,3)){
		case 1:
			rigidbody2D.velocity = new Vector2(3, rigidbody2D.velocity.y);
			break;
		case 2:
			rigidbody2D.velocity = new Vector2(-3, rigidbody2D.velocity.y);
			break;
		default:
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
			break; 
		}
		 
	}
}
