﻿using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;


public enum CharacterState {
	Idle = 0,
	Walking = 1,
	Climbing = 2,
	Running = 3,
	Jumping = 4,
}

public class Player : MonoBehaviour {

	public AudioClip jumpSound;

	public TextMesh text;
	string[] phrases = {
		"Hiiii!",
		"Hey, what's going on?",
		"Heeyyy!",
		"Why are you so quiet?",
		"Nice party huh?",
		"Whooooo!"
	};
	public bool friend = false;
	public bool canMove;
	public bool zone;
	public FriendZone friendZone;
	
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float maxJump;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	private float jumpHold;
	private float maxJumpHold = 10;

	public bool NPC = false; //tells if interacting with NPCs



	public bool canClimb = false;

	public bool grounded;

	
	public CharacterState state;

	Transform topRight;
	Transform topLeft;
	Transform bottomLeft;
	Transform bottomRight;
	
	void Start(){
		maxJump = jumpSpeed;
		state = CharacterState.Idle;
		maxJumpHold = jumpSpeed * 2;

		topRight = transform.Find("top_right").transform;
		topLeft = transform.Find("top_right").transform;
		bottomLeft = transform.Find("bottom_left").transform;
		bottomRight = transform.Find("bottom_right").transform;

	}
	void Move() {

		moveDirection.x = Input.GetAxis("Horizontal")  * speed;;


		if (canClimb){
			if (Mathf.Abs(Input.GetAxis("Vertical")) > 0){
				state = CharacterState.Climbing;
				rigidbody2D.gravityScale = 0;
			}
		}



		if (grounded) {
			state = CharacterState.Walking;
			moveDirection.y = 0;


			
		}
		else if (state != CharacterState.Climbing){
			//rigidbody2D.gravityScale = 1;
			
			//moveDirection.y -= gravity * Time.deltaTime;
		}
		


		//apply gravity



		
		// applying moveDirection
		//moveDirection = transform.TransformDirection(moveDirection);
		//transform.Translate (moveDirection * Time.fixedDeltaTime);
		//rigidbody2D.MovePosition(this.transform.position + moveDirection * Time.fixedDeltaTime);
		Vector2 veloc = rigidbody2D.velocity;
		veloc.x = 0;
		veloc.x = Input.GetAxis ("Horizontal") * Time.fixedDeltaTime * speed * 10;
		rigidbody2D.velocity = veloc ;
		//controller.Move (moveDirection * Time.fixedDeltaTime);
	}

	void Update(){
		grounded = isGrounded ();

		if (grounded && Input.GetButtonDown("Jump")){
			audio.pitch = (jumpSpeed/maxJump);
			audio.PlayOneShot(jumpSound);
			rigidbody2D.AddForce(Vector3.up * jumpSpeed *100);
			//moveDirection.y = jumpSpeed;
			jumpHold = 0;
			state = CharacterState.Jumping;

			if (friendZone != null){
				if (friend){
					jumpSpeed -= maxJump/9.0f;
					                      
				}
				else{
				jumpSpeed -= maxJump/6.0f;
				}
				if (jumpSpeed < maxJump/3f){
					jumpSpeed = maxJump/3f;
				}
				else{friendZone.Unlock();}
			}
		} 

		if (grounded && !zone && jumpSpeed < maxJump) 
		{
			jumpSpeed += 0.1f;
		}

	}

	void FixedUpdate(){
		Move ();

	}

	bool isGrounded(){
		if (moveDirection.y > 0)
						return false;
		int groundOnly = 1 << LayerMask.NameToLayer ("Ground");

		bool g = ((Physics2D.Linecast (bottomLeft.position + Vector3.up, bottomLeft.position, groundOnly) 
						|| Physics2D.Linecast (bottomRight.position + Vector3.up, bottomRight.position, groundOnly))
				//&& rigidbody.velocity.y <= 0);
		          );

		return g;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Zone") 
		{
			zone = true;
			if (other.name !="BuddyZone"){
			int rand = Random.Range(0,phrases.Length);
			Debug.Log(rand);
			Debug.Log("Length: " + phrases.Length);
			text.text = phrases[rand].ToString();
			}
			friendZone = other.GetComponent<FriendZone>();
			Debug.Log(friendZone);
			
		} 

		if (other.tag == "BuddyZone") 
		{
			//zone = false;
			friend = true;
			//friendZone = other.GetComponent<FriendZone>();
			Debug.Log(friendZone);
			
		} 
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Zone") 
		{
			zone = false;
			text.text = "";
			if (friendZone == other.GetComponent<FriendZone>())
				friendZone = null;

		}

		if (other.tag == "BuddyZone") 
		{
			friend = false;
		}
	}

}
