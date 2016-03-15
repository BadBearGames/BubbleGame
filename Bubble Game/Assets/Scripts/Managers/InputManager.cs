using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : Singleton<InputManager>
{
	//Use this class to process input
	protected InputManager() {}

	//Assigned in inspector
	public GameManager gameManager;

	void Update()
	{
		//Process input here
		//Call things like GameManager.player.Move(Direction.up) or something based on current input
		//Place for any user interaction except ui


		/** PLAYER MOVEMENT **/

		//Move left to right
		//Movement is done with WASD/Arrow Keys/Joystick
		if(Input.GetAxis("Horizontal")>0){
			gameManager.player.Move(Vector3.right);
		} else if(Input.GetAxis("Horizontal")<0){
			gameManager.player.Move(Vector3.left);
		}

		//Jump
		//Jump by hitting space, W, or the up arrow
		if(gameManager.player.canJump && (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))){
			gameManager.player.Jump();
			gameManager.player.canJump = false;
		}
	}
}
