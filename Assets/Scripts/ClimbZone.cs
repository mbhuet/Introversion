using UnityEngine;
using System.Collections;

public class ClimbZone : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col){
		Player player = col.gameObject.GetComponent<Player>();
		if (player != null) {
						player.canClimb = true;
				}
	}
	
	void OnTriggerExit2D(Collider2D col){
		Player player = col.gameObject.GetComponent<Player>();
		if (player != null) {

						player.canClimb = false;
						if (player.state == CharacterState.Climbing)
								player.state = CharacterState.Jumping;
				}
	}
	
}
