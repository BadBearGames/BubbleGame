using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	public GameObject wind; 
	// Use this for initialization

	void Start () {
		//var wind = GameObject.Find("Wind");
		wind.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	//when an object collides with the pressure plate
	void OnCollisionEnter(Collision col){
		//Debug.Log("I'm being touched.");
		wind.SetActive(true);
		Debug.Log("Wind is : " + wind.activeSelf);
	}

	//when an object stops colliding with a pressure plate
	void OnCollisionExit(Collision col){
		//Debug.Log("I'm not being touched");
		//Debug.Log("Wind is : " + wind.activeSelf);
		wind.SetActive(false);
		Debug.Log ("Wind is : " + wind.activeSelf);
	}
}
