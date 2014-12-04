using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FriendZone : MonoBehaviour {
	public AudioClip unlockSound;
	public GameObject[] hiddenObjects;
	public Jumper[] jumpers;
	int unlockIndex=0;
	// Use this for initialization
	void Start () {
		if (hiddenObjects.Length > 0) {
						foreach (GameObject obj in hiddenObjects) {
								obj.renderer.enabled = false;
								obj.collider2D.enabled = false;
						}
				}
	}


	public void Unlock(){
		foreach(Jumper j in jumpers){
			//j.rigidbody2D.AddForce(Vector2.up * j.jumpFactor * 10);
			j.bigJump = true;
		}
		if (unlockIndex < hiddenObjects.Length) {
						GameObject obj = hiddenObjects [unlockIndex];
						obj.renderer.enabled = true;
						obj.collider2D.enabled = true;
						unlockIndex ++;
			audio.PlayOneShot(unlockSound);
				}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position, transform.localScale);
	}


}
