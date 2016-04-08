using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Player>() != null)
		{
			Application.LoadLevel("Level Select");
		}
	}
}
