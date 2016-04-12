﻿using UnityEngine;
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
	public ParticleSystem bubbles;
	#endregion

	#region Properties
	public float Mass { get { return body.mass; } }
	public bool IsBubbled { get { return isBubbled; } set { isBubbled = value; } } 
	#endregion

	void Start()
	{
		defaultMaterial = GetComponent<Renderer>().material;
		if (bubbles != null)
		{
			bubbles.Stop();
		}
	}

	void Update()
	{
		//If bubbled up, add a constant force to the rigidbody
		if (IsBubbled)
		{
			//Debug.Log ("Bubbled");
			body.AddForce(Vector3.up * GameManager.Instance.bubbleRiseRate);
			body.AddForce(GameManager.Instance.currentLevelWind.windForce);
		}
	}
}
