using UnityEngine;
using System.Collections;

public class Hazard : Actor {

	bool isHit; 

	// Use this for initialization
	void Start () {
	
		isHit = false; 
	}
	
	// Update is called once per frame
	void Update () {  
		//Debug.Log ("isHit: " + isHit);
	}

	//when this object collides with another object
	void OnCollisionEnter(Collision col){
		
		isHit = true; 
		Debug.Log ("isHit: " + isHit); //hits

		if(col.gameObject.name == "Player"){

		    Debug.Log ("A player stepped on me."); //not hit
		}

	} //end of OnCollisionEnter


	//whent his object stops colliding with another object
	void OnCollisionExit(Collision col){

		isHit = false; 
		Debug.Log ("isHit: " + isHit); //hits

	}//end of OnCollisionEnd

}
