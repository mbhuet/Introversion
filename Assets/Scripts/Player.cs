using UnityEngine;
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
	
	public bool canMove;
	
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	private float oldJumpSpeed;
	private float oldSpeed;
	
	public float maxEnergy = 100;
	public float energy = 100;

	private float jumpHold;
	private float maxJumpHold = 10;
	
	public bool canClimb = false;

	public bool grounded;
	CharacterController controller;
	
	
	public CharacterState state;

	Transform topRight;
	Transform topLeft;
	Transform bottomLeft;
	Transform bottomRight;
	
	void Start(){
		
		state = CharacterState.Idle;
		maxJumpHold = jumpSpeed * 2;

		controller = this.GetComponent<CharacterController>();

		topRight = transform.Find("top_right").transform;
		topLeft = transform.Find("top_right").transform;
		bottomLeft = transform.Find("bottom_left").transform;
		bottomRight = transform.Find("bottom_right").transform;

	}
	void Move() {
		grounded = isGrounded ();

		moveDirection.x = Input.GetAxis("Horizontal")  * speed;;


		if (canClimb){
			if (Mathf.Abs(Input.GetAxis("Vertical")) > 0){
				state = CharacterState.Climbing;
			}
		}

		if (state == CharacterState.Climbing){
			moveDirection.y = Input.GetAxis("Vertical") * speed;
		}


		if (grounded) {
			state = CharacterState.Walking;
			moveDirection.y = 0;

			if (Input.GetButtonDown("Jump")){
				moveDirection.y = jumpSpeed;
				jumpHold = 0;
				state = CharacterState.Jumping;
			}
			
		}
		else if (state != CharacterState.Climbing){
			/*
			//moveDirection += Input.GetAxis("Horizontal") * Vector3.right * speed;
			//moveDirection.x = Mathf.Clamp(moveDirection.x, -speed, speed);	
			if (Input.GetButtonUp("Jump")){
				jumpHold = maxJumpHold;
			}
			// this is used to let players increase jump height by holding the button
			if (Input.GetButton("Jump") && jumpHold < maxJumpHold){
				//moveDirection.y += gravity * Time.fixedDeltaTime /2;
				jumpHold +=1;
			}
			*/
			
			moveDirection.y -= gravity * Time.deltaTime;
		}
		


		//apply gravity



		
		// applying moveDirection
		//moveDirection = transform.TransformDirection(moveDirection);

		rigidbody2D.MovePosition(this.transform.position + moveDirection * Time.deltaTime);
		//controller.Move (moveDirection * Time.fixedDeltaTime);
	}

	void Update(){
		Move ();
		/*
		if (Input.GetButtonDown("Jump")){
			Debug.Log("jump, isGrounded: " + grounded + " ");
		}
		*/
//		Debug.Log (moveDirection.y + " " + grounded);
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


	
	public void Upgrade(){
		jumpSpeed += 5;
		//speed += 3;
		maxJumpHold = jumpSpeed * 2;
	}

	
	
	
	
}
