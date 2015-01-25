using UnityEngine;
using System.Collections;

public class RotatingDeath : MonoBehaviour {

	public float speed = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.MoveRotation (rigidbody2D.rotation + speed * Time.deltaTime);
	}
}
