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

	}
}
