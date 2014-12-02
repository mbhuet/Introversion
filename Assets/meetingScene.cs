using UnityEngine;
using System.Collections;

public class meetingScene : MonoBehaviour {
	
	
	bool a1,a2,a3,a4,a5,a6,a7,a8,a9,a10 = false;
	bool talking; //false if player, true if introvert
	bool done = false;
	public TextMesh text1;
	public TextMesh text2;
	public Transform bubble1;
	public Transform bubble2;
	// Use this for initialization
	void Start () {
		talking = false;
		bubble1.renderer.enabled = false;
		bubble2.renderer.enabled = false;
		text1.text = "";
		text2.text = "";
		StartCoroutine (Wait1(3));
		StartCoroutine (Wait2(6));
		StartCoroutine (Wait3(9));
		StartCoroutine (Wait4(12));
		StartCoroutine (Wait5(15));
		StartCoroutine (Wait6(18));
		StartCoroutine (Wait7(21));
		StartCoroutine (Wait8(24));
	}
	
	// Update is called once per frame
	void Update () {
		if(a1) text2.text = "Hey";
		if (a2) {
			done = false;
			talking = false;
			text2.text = "Do you mind if we go gift shopping together for ~@#&*?";
		}
		if (a3) {
			talking = true;
			text1.text = "Ummm, hey.";
			text2.text = "";
		}
		if (a4) {
			text1.text = "Sure, ~@#&* is a good friend, so I have no problem helping pick out gifts.";
		}
		if (a5) {
			talking = false;
			text1.text = "";
			text2.text = "Thanks for agreeing to go with me.";
		}
		if (a6) {
			text2.text = "I have no idea where to begin looking";
		}
		if (a7) {
			talking = true;
			text2.text = "";
			text1.text = "No problem.";
		}
		if (a8) {
			done = true;
			text2.text = "";
			text1.text = "";
			bubble1.renderer.enabled = true;
			bubble2.renderer.enabled = true;
		}

		/**if (talking && !done) {
					bubble1.renderer.enabled = true;
					bubble2.renderer.enabled = false;
				} else if (!talking && !done) {
					bubble1.renderer.enabled = false;
					bubble2.renderer.enabled = true;
				} else {
					bubble1.renderer.enabled = false;
					bubble2.renderer.enabled = false;
				}
				**/
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
	}
	IEnumerator Wait7(float seconds){
		
		yield return new WaitForSeconds(seconds);
		a7 = true;
	}
	IEnumerator Wait8(float seconds){
		
		yield return new WaitForSeconds(seconds);
		a8 = true;
	}
}
