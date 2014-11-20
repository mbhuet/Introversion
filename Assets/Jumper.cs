using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {
	Transform topRight;
	Transform topLeft;
	Transform bottomLeft;
	Transform bottomRight;

	public float jumpFactor;
	public bool bigJump;

	// Use this for initialization
	void Start(){

		
		topRight = transform.Find("top_right").transform;
		topLeft = transform.Find("top_right").transform;
		bottomLeft = transform.Find("bottom_left").transform;
		bottomRight = transform.Find("bottom_right").transform;

		bottomLeft.transform.position = collider2D.bounds.min + Vector3.down * .1f;
		bottomRight.transform.position = collider2D.bounds.min + Vector3.right * collider2D.bounds.size.x + Vector3.down * .1f;

		
	}
	
	// Update is called once per frame
	void Update () {
		if (isGrounded ()) {
			float bigFactor = 1;
			if (bigJump){
				bigFactor = 2;
				bigJump = false;
			}
			rigidbody2D.AddForce(Vector2.up * Random.Range(1.0f,1.5f) * jumpFactor * bigFactor);
			rigidbody2D.velocity = rigidbody2D.velocity + Vector2.up * .01f;
		}
	}

	bool isGrounded(){
		if (rigidbody2D.velocity.y > 0)
						return false;
		int groundOnly = 1 << LayerMask.NameToLayer ("Ground");
		
		bool g = ((Physics2D.Linecast (bottomLeft.position + Vector3.up, bottomLeft.position, groundOnly) 
		           || Physics2D.Linecast (bottomRight.position + Vector3.up, bottomRight.position, groundOnly))
		          //&& rigidbody.velocity.y <= 0);
		          );
		
		return g;
	}
}
