using UnityEngine;
using System.Collections;

//manages the button related events
public class ButtonManager : MonoBehaviour {

	//when the reset/replay button is pressed
	public void resetLevel(){
		Application.LoadLevel(Application.loadedLevelName);//loads the scene with the same name
	}

	//loads the Level Select scene when the button is pressed
	public void onLevelScreenSelect(){
		Application.LoadLevel("Level Select");
	}

	//loads our main test level when the button is pressed
	public void testLevelSelect(){
		Application.LoadLevel("Main");
	}

	//Loads a level, corresponding to the passed int value
	public void levelSelect(int level){
		Application.LoadLevel("Level"+level);
	}

	//loads the Main Menu/Title Screen
	public void mainMenuSelect(){
		Application.LoadLevel("Title Screen");
	}
}
