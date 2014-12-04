using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public bool follow = false;
	GameObject player;
	bool lateFixedUpdate = false; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 myPos = this.transform.position;
		Vector3 playerPos = player.transform.position;
		
		myPos.y = 0;
		playerPos.y = 0;
		
		float dist = Vector3.Distance(myPos, playerPos);

		if (dist < 5) {
			follow = true;		
		}
		if (follow) {
			Debug.Log("here");


			Vector3 middle = Vector3.Lerp(myPos, playerPos, .5f);
			middle.y = this.transform.position.y;

			//rigidbody2D.MovePosition(middle);
			//this.transform.Translate((playerPos - myPos).normalized * .1f);
			//rigidbody2D.MovePosition(this.transform.position + (playerPos - myPos).normalized * .1f);
			Vector3 vel = rigidbody2D.velocity;
			vel.x = ((playerPos - myPos).normalized * Mathf.Min(dist/3f, 1) * 20).x;
			rigidbody2D.velocity = vel;
		}
	}


	private void LateUpdate(){
		if(lateFixedUpdate){
			lateFixedUpdate = false;
			//LateFixedUpdate();
		}
	}
}
