using UnityEngine;
using System.Collections;

public class bondingScene : MonoBehaviour {
	
	
	bool a1,a2,a3,a4,a5 = false;
	public TextMesh text1;
	public TextMesh text2;
	// Use this for initialization
	void Start () {
		text1.text = "";
		text2.text = "";
		StartCoroutine (Wait1(3));
		StartCoroutine (Wait2(6));
		StartCoroutine (Wait3(10));
		StartCoroutine (Wait4(13));
		StartCoroutine (Wait5(16));
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
}
