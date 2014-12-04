using UnityEngine;
using System.Collections;

public class leavingScene : MonoBehaviour {


	bool a1,a2,a3,a4,a5 = false;
	public TextMesh text;
	public TextMesh text2;
	// Use this for initialization
	void Start () {
		text.text = "";
		text2.text = "";	
		StartCoroutine (Wait1(1));
		StartCoroutine (Wait2(4));
		StartCoroutine (Wait3(8));
		StartCoroutine (Wait4(12));
		StartCoroutine (Wait5(16));
	}
	
	// Update is called once per frame
	void Update () {
		if(a1) text.text = "This was fun.";
		if(a2) text.text = "See you guys at ~@#&*’s birthday party!";
		if (a3) {
			text.text = "";
			text2.text = "Sorry I don't think we'll be able to come.";
				}
		if(a4) text2.text = "You should still go and meet new people!";
		if(a5) Application.LoadLevel(1);
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
