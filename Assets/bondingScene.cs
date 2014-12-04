using UnityEngine;
using System.Collections;

public class bondingScene : MonoBehaviour {

	public FriendZone zone;
	public Jumper bud;

	public GameObject gate;

	bool alreadyDone = false;
	
	bool a1,a2,a3,a4,a5, a6 = false;
	public TextMesh text1;
	public TextMesh text2;
	// Use this for initialization
	void Begin () {
		Debug.Log ("bonding scene");
		text1.text = "";
		text2.text = "";
		StartCoroutine (Wait1(3));
		StartCoroutine (Wait2(6));
		StartCoroutine (Wait3(10));
		StartCoroutine (Wait4(13));
		StartCoroutine (Wait5(16));
		StartCoroutine (Wait6(20));

	}
	
	// Update is called once per frame
	void Update () {
		if(a1) text2.text = "Why are you being so quiet?";
		if (a2) {
			text2.text = "";
			text1.text = "I'm just not used to being with so many unfamiliar people.";
				}
		if (a3) {
			text1.text = "";
			text2.text = "I feel you.";
				}
		if (a4) {
			text2.text = "I’ll just stick around with you.";
				}
		if (a5) {
			text2.text = "This isn’t my kind of crowd either.";
				}
		if (a6) {
			text2.text = "";
		}
	}
	
	
	IEnumerator Wait1(float seconds){
		
		yield return new WaitForSeconds(seconds);
		a1 = true;
	}
	
	IEnumerator Wait2(float seconds){
		
		yield return new WaitForSeconds(seconds);
		a2 = true;
	}
	IEnumerator Wait3(float seconds){
		
		yield return new WaitForSeconds(seconds);
		a3 = true;
	}
	IEnumerator Wait4(float seconds){
		
		yield return new WaitForSeconds(seconds);
		a4 = true;
	}
	IEnumerator Wait5(float seconds){
		
		yield return new WaitForSeconds(seconds);
		a5 = true;
	}
	IEnumerator Wait6(float seconds){
		
		yield return new WaitForSeconds(seconds);
		a6 = true;
		Color mustard = new Color (234f/255f,212f/255f,67f/255f);
		bud.renderer.material.color = mustard;

		bud.jumpFactor = 300;

		zone.tag = "BuddyZone";

		GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>().zone = false;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>().maxJump += 3;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>().friendZone = null;

		GameObject.Destroy (gate.gameObject);

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" && !alreadyDone) {
						Begin ();
			alreadyDone = true;
				}
	}
}
