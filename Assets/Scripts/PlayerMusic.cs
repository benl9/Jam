using UnityEngine;
using System.Collections;

public class PlayerMusic : MonoBehaviour {
	public AudioClip[] background = new AudioClip[2];
	public AudioClip[] end = new AudioClip[5];
	CameraFollow cameraMain; 
	PlayerStatus status; 
	// Use this for initialization
	void Start () {
		cameraMain = GameObject.Find ("Main Camera").GetComponent<CameraFollow>(); 
		status = GetComponent<PlayerStatus>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Checkpoint"){
			if(collision.gameObject.name == "Start"){
				if(cameraMain.gameObject.audio.clip != background[0]){
					cameraMain.gameObject.audio.clip = background[0];
					cameraMain.gameObject.audio.Play();
				} 
			}
			else if(collision.gameObject.name == "End"){
				if(cameraMain.gameObject.audio.clip != background[1]){
					cameraMain.gameObject.audio.clip = background[1];
					cameraMain.gameObject.audio.Play();
				}
				if(status.kills < 7){
					if(audio.clip != end[0]){
						audio.clip = end[0];
						StartCoroutine("playMusic");
					}
				}
				else if(status.kills >= 7 && status.kills < 13){
					if(audio.clip != end[1]){
						audio.clip = end[1];
						StartCoroutine("playMusic");
					}
				}
				else if(status.kills >= 13 && status.kills < 19){
					if(audio.clip != end[1]){
						audio.clip = end[2];
						StartCoroutine("playMusic");
					}
				}
				else if(19 <= status.kills){
					if(audio.clip != end[3]){
						audio.clip = end[3];
						StartCoroutine("playMusic");
					}
				}
			}
		}
	}
	
	IEnumerator playMusic(){
		audio.Play (); 
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = end[4]; 
		audio.Play (); 
	}
}
