using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : Singleton<InputManager> 
{
	//Use this class to process input
	protected InputManager() {}

	void Update()
	{
		//Process input here
		//Call things like GameManager.Instance.player.Move(Direction.up) or something based on current input
		//Place for any user interaction except ui
		//Raycast and detect which object we are grabbing
		if (Input.GetMouseButtonDown(0))
		{
			ProcessClick();
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
