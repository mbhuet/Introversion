using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {
	public bool activated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.GetComponent<Player>()){
			activated = true;
		}
	}
	
	public void Reset(){
		activated = false;
	}
}
