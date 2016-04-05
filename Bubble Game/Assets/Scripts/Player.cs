using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//Assigned in inspector
	public float speed;
	public float jumpHeight;

	//Boolean to prevent...
	public bool canJump;		//...multiple jumps
	public bool canMoveLeft;	//...wall hanging
	public bool canMoveRight;	//...wall hanging pt2

	//Vector3 to store the player's respawn point
	public Vector3 spawnPoint; 

	//Rigidbody of Player
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		canMoveLeft = true;
		canMoveRight = true;

		//assign rigidbody
		rb = GetComponent<Rigidbody>();

		//We do not want a negative or 0 speed!
		if(speed<0){
			speed = .1f;
		}
		//We do not want a negative or 0 jump height!
		if(jumpHeight<0){
			jumpHeight = 1.0f;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(canMove);
		if(transform.position.y<-20){
			Kill();
		}
	}

	//Function to handle player death
	//Called when player needs to be killed/respawned
	void Kill(){
		Debug.Log("Player Died");
		transform.position = spawnPoint; //changes the player's position to equal the spawn point
	}

	/** MOVEMENT FUNCTIONS **/
	//Move Function
	//Player Moves Left or Right when A/D, Left/Right Arrow, or Joystick is used
	public void Move(Vector3 movement){
		//transform.Translate(movement*speed);
		rb.velocity = new Vector3 (movement.x*speed, rb.velocity.y, rb.velocity.z);
	}

	//Jump Function
	//Player Jumps with Space/W/Up Arrow is hit
	public void Jump(){
		rb.velocity = new Vector3 (rb.velocity.x, jumpHeight, rb.velocity.z);
		canJump = false;
	}

	/** COLLISION DETECTION FUNCTIONS **/
	//Function to handle collision detection
	//Called when the collision starts
	void OnCollisionEnter(Collision collision){
		//Debug.Log(collision.contacts[0].normal.x+", "+collision.contacts[0].normal.y+", "+collision.contacts[0].normal.z);

		//If we hit a platform, we can jump again!
		//But only if we hit the top of it (ie no wall jumping)
		if(collision.gameObject.tag == "Platform" || collision.gameObject.tag == "BubbleBlock"){
			if(collision.contacts[0].normal.y == 1){
				canJump = true;
			}
		//If the Player hits a Hazard
		}else if(collision.gameObject.tag == "Hazard"){
			Kill();
		}
	}

	//Function to handle collision detection
	//Called when the collision persists
	void OnCollisionStay(Collision collision){
		//stop player from hanging on the wall

		//if player is moving right and there is a collision to our right
		//if player is moving left and there is a collision to our left
		//Cancel left to right movement
		foreach(ContactPoint contact in collision.contacts){
			//Debug.Log(rb.velocity.x+", "+contact.normal.x);
			if(contact.normal.x < 0){
				canMoveRight = false;
			} else if(contact.normal.x > 0){
				canMoveLeft = false;
			}
		}
	}

	//Function to handle collision detection
	//Called when collision ends
	void OnCollisionExit(Collision collision){
		canMoveLeft = true;
		canMoveRight = true;
	}
}
