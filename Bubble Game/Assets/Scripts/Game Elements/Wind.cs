using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour 
{
	#region Fields
	//Assigned in inspector
	public WindZone windZone;
	public Vector3 windForce; //Set this in inspector, this will affect the rigidbodies
	#endregion

	void Awake()
	{
		GameManager.Instance.currentLevelWind = this;
	}

	void Start()
	{
		//Set windzones rotation and force to the wind force
		windZone.transform.rotation = Quaternion.LookRotation(windForce);
		windZone.windMain = windForce.magnitude;
	}
}
