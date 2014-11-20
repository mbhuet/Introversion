using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			renderer.enabled = false;	
			audio.Play();
			particleSystem.Emit(10);
			StartCoroutine("kill",2);
		}
	}


	IEnumerator kill(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}
