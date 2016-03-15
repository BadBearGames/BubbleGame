using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Actor : MonoBehaviour 
{
	#region Fields
	//Private
	private bool isBubbled;
	private Material defaultMaterial;

	//Assigned in inspector
	public Rigidbody body;
	#endregion

	#region Properties
	public float Mass { get { return body.mass; } }
	public bool IsBubbled { get { return isBubbled; } set { isBubbled = value; } } 
	#endregion

	void Start()
	{
		defaultMaterial = GetComponent<Renderer>().material;
	}

	void Update()
	{
		//If bubbled up, add a constant force to the rigidbody
		if (IsBubbled)
		{
			body.AddForce(Vector3.up * GameManager.Instance.bubbleRiseRate);
			body.AddForce(GameManager.Instance.currentLevelWind.windForce);

			//Dumb logic we will delete
			if (GetComponent<Renderer>().material != GameManager.Instance.tempBubbleMaterial)
			{
				GetComponent<Renderer>().material = GameManager.Instance.tempBubbleMaterial;
			}
		}
		else
		{
			if (GetComponent<Renderer>().material != defaultMaterial)
			{
				GetComponent<Renderer>().material = defaultMaterial;
			}
		}
	}
}
