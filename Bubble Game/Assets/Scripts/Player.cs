using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//Assigned in inspector
	public float speed;
	public float jumpHeight;

	//Boolean to prevent multiple jumps
	public bool canJump;

	//Vector3 to store the player's respawn point
	public Vector3 spawnPoint; 

	//Rigidbody of Player
	Rigidbody rb;

	// Use this for initialization
	void Start () {
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
	
	}

	//Move Function
	//Player Moves Left or Right when A/D, Left/Right Arrow, or Joystick is used
	public void Move(Vector3 movement){
		transform.Translate(movement*speed);
	}

	//Jump Function
	//Player Jumps with Space/W/Up Arrow is hit
	public void Jump(){
		rb.velocity = new Vector3 (rb.velocity.x, jumpHeight, rb.velocity.z);
	}

	//Function to handle collision detection
	void OnCollisionEnter(Collision collision){
		//If we hit a platform, we can jump again!
		if(collision.gameObject.tag == "Platform"){
			canJump = true;
		//If the Player hits a Hazard
		}else if(collision.gameObject.tag == "Hazard"){
			transform.position = spawnPoint; 
			//Debug.Log("AHHHHHHHHHHHHHHHHHHHH!"); 
		}
	}
}
