using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	
	Vector2 velocity;
	Vector2 smoothTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 camPos = transform.position;
		Vector3 targetPos = target.position;
		
		transform.position = new Vector3(Mathf.SmoothDamp(camPos.x, targetPos.x, ref velocity.x, smoothTime.x, Mathf.Infinity, Time.deltaTime),
		                                 Mathf.SmoothDamp(camPos.y, targetPos.y, ref velocity.y, smoothTime.y, Mathf.Infinity, Time.deltaTime),
		                                 camPos.z);
	}
}
