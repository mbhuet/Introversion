using UnityEngine;
using System.Collections;

public class leavingScene : MonoBehaviour {


	bool a1,a2,a3,a4 = false;
	public TextMesh text;
	// Use this for initialization
	void Start () {
		text.text = "";
		StartCoroutine (Wait1(1));
		StartCoroutine (Wait2(4));
		StartCoroutine (Wait3(8));
	}
	
	// Update is called once per frame
	void Update () {
		if(a1) text.text = "This was fun.";
		if(a2) text.text = "I’ll see you guys at ~@#&*’s birthday party next week!";
		if(a3) Application.LoadLevel(1);
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
}
