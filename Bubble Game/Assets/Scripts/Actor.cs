using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour 
{
	RequireComponent Rigidbody;

	#region Fields
	//Private

	//Assigned in inspector
	public Rigidbody body;
	#endregion

	#region Properties
	public float Mass { get { return body.mass; } }
	#endregion


}
