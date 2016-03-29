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
		//Raycast and detect which object we are grabbing
		if (Input.GetMouseButtonDown(0))
		{
			ProcessClick();
		}

		/** PLAYER MOVEMENT **/
		Player player = gameManager.player;

		//Move left to right
		//Movement is done with WASD/Arrow Keys/Joystick
		if(Input.GetAxis("Horizontal")>0 && player.canMoveRight){
			player.Move(Vector3.right);
		} else if(Input.GetAxis("Horizontal")<0 && player.canMoveLeft){
			player.Move(Vector3.left);
		}
	
		//Jump
		//Jump by hitting space, W, or the up arrow
		if(player.canJump && (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))){
			player.Jump();
		}
	}

	/// <summary>
	/// Checks raycasts using the mouse position on the camera
	/// </summary>
	private void ProcessClick()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 100f))
		{
			//Bubble up a gameobject if it is an actor script
			if (hit.collider.gameObject.GetComponent<Actor>() != null)
			{
				GameManager.Instance.BubbleUp(hit.collider.gameObject.GetComponent<Actor>());
			}
		}
	}
}
