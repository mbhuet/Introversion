using UnityEngine;
using System.Collections;

public class FollowNPC : MonoBehaviour {
	float y;
	public GameObject target;
	// Use this for initialization
	void Start () {
		y = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = target.transform.position;
		//pos.y = this.y;
		this.transform.position = pos;
	}
}
