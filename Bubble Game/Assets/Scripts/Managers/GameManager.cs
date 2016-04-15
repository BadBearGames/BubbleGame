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
	//For bubbles
	private List<Actor> bubbledActors;

	//Assigned in inspector
	public Player player;
	public float bubbleRiseRate;
	public Material tempBubbleMaterial;
	public Wind currentLevelWind;
	//public int maxBubbleCount;
	#endregion

	#region Properties
	public GameState State { get { return state; } }
	public List<Actor> BubbledActors { get { return bubbledActors; } }

    private float cameraFollowDistance;
	#endregion


	protected GameManager() {}

	void Awake()
	{
		DontDestroyOnLoad(this);
		Init();
	}

	public void Init()
	{
		state = GameState.None;
		bubbledActors = new List<Actor>();

        cameraFollowDistance = 1.0f;

		/*GameObject playerGO = GameObject.Find("Player");
		if (playerGO != null)
		{
			player = playerGO.GetComponent<Player>();
			currentLevelWind = GameObject.Find("Wind").GetComponent<Wind>();
		}*/
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

		//Probably stick this under a gamestate in the future
		if (player != null)
		{
			CameraFollowPlayer();
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
		actor.IsBubbled = !actor.IsBubbled;
		SoundManager.Instance.PlayEffect("pop");

		if (actor.IsBubbled)
		{
			bubbledActors.Add(actor);

			if (actor.bubbles != null)
			{
				actor.bubbles.Play();
			}
		}
		else
		{
			bubbledActors.Remove(actor);
			
			if (actor.bubbles != null)
			{
				actor.bubbles.Stop();
				actor.bubbles.Clear();
			}
		}
	}

	/// <summary>
	/// Makes the camera follow the player
	/// </summary>
	public void CameraFollowPlayer(){
        
		Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, player.transform.position.y + 1, Camera.main.transform.position.z);

		if(player.transform.position.x > Camera.main.transform.position.x+ cameraFollowDistance)
			Camera.main.transform.position = new Vector3(player.transform.position.x - cameraFollowDistance, player.transform.position.y + 1, Camera.main.transform.position.z);

		if(player.transform.position.x < Camera.main.transform.position.x- cameraFollowDistance)
			Camera.main.transform.position = new Vector3(player.transform.position.x + cameraFollowDistance, player.transform.position.y + 1, Camera.main.transform.position.z);

    }

}

