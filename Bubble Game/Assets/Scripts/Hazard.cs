using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {  
		//Debug.Log ("isHit: " + isHit);
	}

	//when this object collides with another object
	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "Player"){
		}

	} //end of OnCollisionEnter


	//whent his object stops colliding with another object
	void OnCollisionExit(Collision col){
	}//end of OnCollisionEnd

}
