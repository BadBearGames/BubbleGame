using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
	None
}

public class GameManager : Singleton<GameManager> 
{
	#region Fields
	//Private
	private GameState state;
	private float stateTimer;

	//Assigned in inspector
	public Player player;
	#endregion

	#region Properties
	public GameState State { get { return state; } }
	#endregion


	protected GameManager() {}

	void Awake()
	{
		state = GameState.None;
	}

	public void Init()
	{
		
	}

	void Update()
	{
		//Switch gamestate using a timer
		if (stateTimer > 0f)
		{
			stateTimer -= Time.deltaTime;
		}
		else
		{
			//Switch state or something
			switch (state)
			{
			case GameState.None:
				SwitchGameState(GameState.None);
				break;
			}
		}
	}

	/// <summary>
	/// For switching gameplay logic
	/// </summary>
	/// <param name="state">State.</param>
	public void SwitchGameState(GameState state)
	{
		switch (state)
		{
		case GameState.None:
			//Do something here
			break;
		}
		this.state = state;
	}

	/// <summary>
	/// Makes a bubble around the param gameobject
	/// </summary>
	/// <param name="actor">Actor.</param>
	public void BubbleUp(Actor actor)
	{
		
	}
}

